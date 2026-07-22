using BepInEx;
using ExitGames.Client.Photon;
using GorillaCraft.Behaviours.Blocks;
using GorillaCraft.Behaviours.Networking;
using GorillaCraft.Behaviours.UI;
using GorillaCraft.Models;
using GorillaCraft.Tools;
using GorillaCraft.Utilities;
using GorillaLibrary.Extensions;
using GorillaLibrary.Models;
using GorillaLibrary.Utilities;
using GorillaTag;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace GorillaCraft.Behaviours;

public class MainScript : MonoBehaviourPunCallbacks
{
    public static MainScript Instance { get; private set; }

    public static BlockScript BlockScript { get; private set; }

    public static BuildScript BuildScript { get; private set; }

    public bool InModdedRoom => _inModdedRoom.GetValueOrDefault(false);

    public ReadOnlyDictionary<Player, GorillaCrafter> Players => new(_players);

    public AssetLoaderSync AssetLoader;

    public Configuration Config;

    private bool? _inModdedRoom;

    private MenuHandler _menuHandler;

    private GameModeUIHandler _gamemodeHandler;

    private bool _currentModeBinding;

    private Dictionary<byte, BlockSoundObject> _sounds;

    private readonly Dictionary<Player, GorillaCrafter> _players = [];

    public void Start()
    {
        if (Instance != null) return;
        Instance = this;

        enabled = false;
        BlockScript = GetComponent<BlockScript>();
        BuildScript = GetComponent<BuildScript>();

        var bundle = AssetLoader.GetBundle();
        _sounds = bundle.LoadAllAssets<BlockSoundObject>().ToDictionary(sound => sound.SoundId, sound => sound);

        Plugin.InModdedRoom.AddCallback(OnModdedStateChanged);

        GameObject itemSelectionMenu = Instantiate(AssetLoader.LoadAsset<GameObject>(Constants.ItemSelectorName));
        itemSelectionMenu.transform.SetParent(GorillaTagger.Instance.offlineVRRig.leftHandTransform.parent);

        _menuHandler = itemSelectionMenu.AddComponent<MenuHandler>();
        _menuHandler.AssetLoader = AssetLoader;
        _menuHandler.Config = Config;
        _menuHandler.Placement = BuildScript;

        GameObject modeSelectionMenu = Instantiate(AssetLoader.LoadAsset<GameObject>("GamemodeSelector"));
        modeSelectionMenu.SetActive(false);
        modeSelectionMenu.transform.SetParent(GorillaTagger.Instance.offlineVRRig.leftHandTransform.parent);

        _gamemodeHandler = modeSelectionMenu.AddComponent<GameModeUIHandler>();
        _gamemodeHandler._offSprite = AssetLoader.LoadAsset<Sprite>("slot");
        _gamemodeHandler._onSprite = AssetLoader.LoadAsset<Sprite>("selection");
        _gamemodeHandler._placementHelper = BuildScript;

        // required for networking
        PhotonNetwork.LocalPlayer.SetCustomProperties(new() { { "GC", Plugin.Info.Metadata.Version.ToString() } });

        enabled = true;
    }

    public void Update()
    {
        if (!InModdedRoom)
        {
            _gamemodeHandler.gameObject.SetActive(false);
            _menuHandler.gameObject.SetActive(false);
            return;
        }

        bool buttonHeld = ControllerInputPoller.instance.leftControllerSecondaryButton;
        if (buttonHeld && buttonHeld != _currentModeBinding)
        {
            _gamemodeHandler.gameObject.SetActive(true);
            _menuHandler.gameObject.SetActive(false);
        }
        else if (!buttonHeld && buttonHeld != _currentModeBinding)
        {
            _gamemodeHandler.gameObject.SetActive(false);
            _menuHandler.gameObject.SetActive(BuildScript.InteractMode == 0);
        }

        _currentModeBinding = buttonHeld;
    }

    private void OnModdedStateChanged(bool state)
    {
        if (GTAppState.isQuitting || (_inModdedRoom.HasValue && state == _inModdedRoom.Value)) return;

        _inModdedRoom = state;

        if (state)
        {
            _menuHandler.gameObject.SetActive(BuildScript.InteractMode != 2);

            PhotonNetwork.NetworkingClient.EventReceived += OnEvent;
            RigUtility.LocalRig.gameObject.AddComponent<GorillaCrafter>();
            return;
        }

        _gamemodeHandler.gameObject.SetActive(false);
        _menuHandler.gameObject.SetActive(false);

        PhotonNetwork.NetworkingClient.EventReceived -= OnEvent;
        if (RigUtility.LocalRig.TryGetComponent(out GorillaCrafter component)) component.Remove();
    }

    public void OnEvent(EventData data)
    {
        if (data.Code != NetworkUtility.EventCode) return;

        object[] eventData = (object[])data.CustomData;
        if (eventData.Length == 0 || eventData[0] is not int) return;

        int eventId = (int)eventData[0];
        if (eventId != NetworkUtility.Id_BlockInteraction && eventId != NetworkUtility.Id_SurfaceTap && eventId != NetworkUtility.Id_RequestBlocks && eventId != NetworkUtility.Id_SendBlocks) return;

        Player sender = PhotonNetwork.CurrentRoom.GetPlayer(data.Sender);

        Logging.Info($"{sender.NickName} ({string.Join(", ", eventData)})");

        try
        {
            if (eventId == NetworkUtility.Id_BlockInteraction)
            {
                AddUser(sender);

                /*
                
                0 = build/destroy (boolean)
                1 = block id (short) [A] / instance id (string) [B]
                2 = instance id (string)
                3 = parent id (string)
                4 = parent face (byte)
                5 = position (long)
                6 = rotation (long)
                7 = scale (float)

                A = when building (0-7)
                B = when destroying (0-1)

                */

                bool build = (bool)eventData[0 + 1];

                if (build && Guid.TryParse(eventData[2 + 1].ToString(), out Guid builtSerialNumber))
                {
                    Guid parentSerialNumber = default;
                    bool hasParentGuid = eventData[3 + 1] is string guidString && Guid.TryParse(guidString, out parentSerialNumber);

                    Block parentBlock = null;
                    if (hasParentGuid && !BlockScript.TryFindBlock(parentSerialNumber, out parentBlock))
                    {
                        Logging.Error($"Parent Block ID was provided but actual block is missing - {parentSerialNumber}");
                        return;
                    }

                    if (hasParentGuid && eventData[4 + 1] is not byte)
                    {
                        Logging.Error("Parent Block face was not provided");
                        return;
                    }

                    bool result = BlockScript.PlaceBlock(BlockPlaceType.Server, (short)eventData[1 + 1], builtSerialNumber, Utils.UnpackVector3FromLong((long)eventData[5 + 1]), Utils.UnpackVector3FromLong((long)eventData[6 + 1]), (float)eventData[7 + 1], sender, out var createdBlock, BlockInclusions.Audio);

                    if (result && hasParentGuid)
                    {
                        byte parentFace = (byte)eventData[4 + 1];
                        var face = parentBlock[parentFace];
                        face.ChildBlocks.Add(createdBlock);
                        createdBlock.ParentalBlock = face.Root;
                    }

                    return;
                }

                if (Guid.TryParse(eventData[1 + 1].ToString(), out Guid removedSerialNumber))
                {
                    BlockScript.RemoveBlock(removedSerialNumber, sender);
                    return;
                }

                return;
            }

            if (eventId == NetworkUtility.Id_SurfaceTap)
            {
                if (eventData[0 + 1] is byte soundId && _sounds.TryGetValue(soundId, out BlockSoundObject blockSound))
                {
                    BlockScript.PlayTapSound(VRRigCache.Instance.TryGetVrrig(sender, out RigContainer playerRig) ? playerRig.Rig : null, blockSound, (bool)eventData[1 + 1]);
                    return;
                }

                return;
            }

            if (eventId == NetworkUtility.Id_RequestBlocks)
            {
                if (sender.IsLocal) return;

                AddUser(sender);

                Logging.Message("sending blocks");

                ThreadingHelper.Instance.StartSyncInvoke(async () =>
                {
                    List<object[]> totalData = [];

                    var all = GorillaCrafter.Local.Blocks.Values;
                    var independent = all.Where(block => block.ParentalBlock.IsObjectNull());
                    var sorted = independent.Concat(all.Except(independent)).ToArray();

                    Player player = (Player)eventData[0 + 1];

                    foreach (var block in sorted)
                    {
                        if (totalData.Count > 10)
                        {
                            NetworkUtility.SendBlocks(player, totalData);
                            totalData.Clear();
                            await Task.Delay(150);
                        }

                        object[] data =
                        [
                            block.Reference.BlockId,
                            Utils.PackVector3ToLong(block.Position),
                            Utils.PackVector3ToLong(block.EulerAngles),
                            block.Size,
                            block.SerialNumber.ToString(),
                            block.ParentalBlock.IsObjectExistent() ? block.ParentalBlock.SerialNumber.ToString() : 0,
                            (block.ParentalBlock.IsObjectExistent() && block.ParentalBlock.FindChildFace(block) is BlockFace face && face.IsObjectExistent()) ? block.ParentalBlock.GetIndex(face) : 0
                        ];

                        totalData.Add(data);
                        Logging.Info(string.Join(" / ", data));
                    }

                    if (totalData.Count > 0)
                    {
                        await Task.Delay(150);
                        NetworkUtility.SendBlocks(player, totalData);
                    }
                });

                return;
            }

            if (eventId == NetworkUtility.Id_SendBlocks)
            {
                if (sender.IsLocal) return;

                Logging.Info("sent blocks");

                ThreadingHelper.Instance.StartSyncInvoke(async () =>
                {
                    await Task.Delay(500);

                    int minActorNum = NetworkSystem.Instance.AllNetPlayers.Select(netPlayer => netPlayer.ActorNumber).Min();
                    int baseActorNum = sender.ActorNumber - minActorNum;
                    if (baseActorNum > 0)
                    {
                        int delay = baseActorNum * 200;
                        Logging.Info($"Construction delay by {delay} milliseconds ({minActorNum}, {baseActorNum})");
                        await Task.Delay(delay);
                    }

                    void ScanBlocks(object[] blockData)
                    {
                        Logging.Info($"Constructing {Mathf.Floor(blockData.Length / 4f)} blocks");

                        short blockId = 0;
                        long blockPosition = 0;
                        long blockRotation = 0;
                        float blockSize = 1f;
                        Guid blockSerialNumber = default;
                        Guid blockParentSerialNumber = default;
                        byte blockParentSide = 0;
                        bool useParent = true;
                        Block parentBlock = null;

                        for (int i = 0; i < blockData.Length; i++)
                        {
                            object blkData = blockData[i];
                            int blkDataIndex = i % 7;
                            Logging.Info($"#{blkDataIndex}: {blkData}");

                            try
                            {
                                switch (blkDataIndex)
                                {
                                    case 0:
                                        blockId = (short)blkData;
                                        break;
                                    case 1:
                                        blockPosition = (long)blkData;
                                        break;
                                    case 2:
                                        blockRotation = (long)blkData;
                                        break;
                                    case 3:
                                        blockSize = (float)blkData;
                                        break;
                                    case 4:
                                        if (Guid.TryParse(blkData.ToString(), out Guid guid))
                                        {
                                            blockSerialNumber = guid;
                                            break;
                                        }
                                        throw new InvalidOperationException();
                                    case 5:
                                        if (useParent && Guid.TryParse(blkData.ToString(), out Guid parentGuid) && BlockScript.TryFindBlock(parentGuid, out Block block))
                                        {
                                            blockParentSerialNumber = parentGuid;
                                            parentBlock = block;
                                            break;
                                        }
                                        useParent = false;
                                        break;
                                    case 6:
                                        if (useParent && blkData is byte side)
                                        {
                                            blockParentSide = side;
                                            goto CreateBlock;
                                        }

                                        useParent = false;
                                    CreateBlock:

                                        BlockScript.PlaceBlock
                                        (
                                            BlockPlaceType.Sent,
                                            blockId,
                                            blockSerialNumber,
                                            Utils.UnpackVector3FromLong(blockPosition),
                                            Utils.UnpackVector3FromLong(blockRotation),
                                            blockSize,
                                            sender,
                                            out Block createdBlock,
                                            BlockInclusions.None
                                        );

                                        if (useParent)
                                        {
                                            var face = parentBlock[blockParentSide];
                                            face.ChildBlocks.Add(createdBlock);
                                            createdBlock.ParentalBlock = face.Root;
                                        }

                                        useParent = true;

                                        break;
                                }

                                float progress = Mathf.Round((blkDataIndex + 1) / 7f * 100f);
                                Logging.Info($"Block construction at {progress}%");
                            }
                            catch (Exception ex)
                            {
                                Logging.Error($"Block constructon threw an exception: {ex}");
                                i += 7 - blkDataIndex; // skip this block
                                useParent = true;
                                Logging.Warning("Construction skipped");
                                continue;
                            }
                        }
                    }

                    for (int i = 1; i < eventData.Length; i++)
                    {
                        if (eventData[i] is object[] blockData)
                        {
                            ScanBlocks(blockData);
                            await Task.Delay(120);
                        }
                    }
                });

                return;
            }
        }
        catch (Exception ex)
        {
            Logging.Error(ex);
        }
    }

    public bool IsUser(Player player) => _players.ContainsKey(player);

    public bool IsUser(GorillaCrafter component) => _players.ContainsValue(component);

    public void AddUser(Player player)
    {
        if (_players.ContainsKey(player) || !VRRigCache.Instance.TryGetVrrig(player, out RigContainer playerRig) || !playerRig.TryGetComponent(out GorillaCrafter component) || component.IsPunished) return;
        _players.Add(player, component);

        Logging.Message($"{player} has been added as a GorillaCraft User");
    }

    public void RemoveUser(Player player)
    {
        if (!_players.ContainsKey(player)) return;
        _players.Remove(player);

        Logging.Message($"{player} has been removed as a GorillaCraft User");
    }
}
