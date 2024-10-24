using ExitGames.Client.Photon;
using GorillaCraft.Behaviours.Networking;
using GorillaCraft.Behaviours.UI;
using GorillaCraft.Models;
using GorillaCraft.Tools;
using GorillaCraft.Utilities;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace GorillaCraft.Behaviours
{
    public class Main : MonoBehaviourPunCallbacks, IInitializable
    {
        public static bool InModdedRoom;

        private AssetLoader _assetLoader;
        private Configuration _config;

        private PlacementHelper _placementHelper;
        private MenuHandler _menuHandler;
        private GameModeUIHandler _gamemodeHandler;

        private bool _currentModeBinding;

        [Inject]
        public void Construct(PlacementHelper placementHelper, AssetLoader assetLoader, Configuration configuration)
        {
            _placementHelper = placementHelper;
            _assetLoader = assetLoader;
            _config = configuration;
        }

        public async void Initialize()
        {
            Plugin.Allowed.AddCallback(AllowStateChanged);

            GameObject itemSelectionMenu = Instantiate(await _assetLoader.LoadAsset<GameObject>("ItemSelector"));
            itemSelectionMenu.transform.SetParent(GorillaTagger.Instance.offlineVRRig.leftHandTransform.parent);

            _menuHandler = itemSelectionMenu.AddComponent<MenuHandler>();
            _menuHandler.AssetLoader = _assetLoader;
            _menuHandler.Config = _config;
            _menuHandler.Placement = _placementHelper;

            GameObject modeSelectionMenu = Instantiate(await _assetLoader.LoadAsset<GameObject>("GamemodeSelector"));
            modeSelectionMenu.SetActive(false);
            modeSelectionMenu.transform.SetParent(GorillaTagger.Instance.offlineVRRig.leftHandTransform.parent);

            _gamemodeHandler = modeSelectionMenu.AddComponent<GameModeUIHandler>();
            _gamemodeHandler._offSprite = await _assetLoader.LoadAsset<Sprite>("slot");
            _gamemodeHandler._onSprite = await _assetLoader.LoadAsset<Sprite>("selection");
            _gamemodeHandler._placementHelper = _placementHelper;

            PhotonNetwork.LocalPlayer.SetCustomProperties(new() { { "GC", Constants.Version } });
        }

        public void Update()
        {
            if (!_gamemodeHandler || !_menuHandler) return;

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
                _menuHandler.gameObject.SetActive(PlacementHelper.InteractMode == 0);
            }

            _currentModeBinding = buttonHeld;
        }

        private void AllowStateChanged(bool state)
        {
            InModdedRoom = state;
            if (InModdedRoom)
            {
                _menuHandler.gameObject.SetActive(PlacementHelper.InteractMode != 2);
            }
            else
            {
                _gamemodeHandler.gameObject.SetActive(false);
                _menuHandler.gameObject.SetActive(false);
            }
        }

        public override async void OnJoinedRoom()
        {
            base.OnJoinedRoom();
            PhotonNetwork.NetworkingClient.EventReceived += OnEvent;
            GorillaTagger.Instance.offlineVRRig.gameObject.AddComponent<GorillaCrafter>();
        }

        public override void OnLeftRoom()
        {
            base.OnLeftRoom();
            PhotonNetwork.NetworkingClient.EventReceived -= OnEvent;
            Destroy(GorillaTagger.Instance.offlineVRRig.gameObject.GetComponent<GorillaCrafter>());
        }

        public async void OnEvent(EventData data)
        {
            if (data.Code != (int)GorillaCraftNetworkType.BlockInteractionCode && data.Code != (int)GorillaCraftNetworkType.SurfaceTapCode && data.Code != (int)GorillaCraftNetworkType.RequestBlocksCode && data.Code != (int)GorillaCraftNetworkType.SendBlocksCode) return;

            Player sender = PhotonNetwork.CurrentRoom.GetPlayer(data.Sender);
            object[] eventData = (object[])data.CustomData;

            Logging.Info($"{sender.NickName} ({string.Join(", ", eventData)})");

            if (data.Code == (int)GorillaCraftNetworkType.BlockInteractionCode)
            {
                bool build = (bool)eventData[0];

                if (build)
                {
                    GorillaLocomotion.Player.Instance.GetComponent<BlockHandler>().PlaceBlock(BlockPlaceType.Server, (string)eventData[1], Utils.UnpackVector3FromLong((long)eventData[2]), Utils.UnpackVector3FromLong((long)eventData[3]), Utils.UnpackVector3FromLong((long)eventData[4]), sender, out _, BlockInclusions.Audio);
                    return;
                }

                GorillaLocomotion.Player.Instance.GetComponent<BlockHandler>().RemoveBlock((long)eventData[1], sender);
                return;
            }

            if (data.Code == (int)GorillaCraftNetworkType.SurfaceTapCode)
            {
                Type surfaceType = typeof(Plugin).Assembly.GetType((string)eventData[0]);
                if (surfaceType != null)
                {
                    GorillaLocomotion.Player.Instance.GetComponent<BlockHandler>().PlayTapSound(RigCacheUtils.GetRigContainer(sender).Rig, surfaceType, (bool)eventData[1]);
                }
                return;
            }

            if (data.Code == (int)GorillaCraftNetworkType.RequestBlocksCode)
            {
                if (sender.IsLocal) return;

                Player player = (Player)eventData[0];
                List<object> blocks = [];

                foreach (var block in GorillaCrafter.Local.Blocks.Values)
                {
                    if (Mathf.FloorToInt(blocks.Count / 4f) >= 10)
                    {
                        Logging.Info(string.Format("Sending current list of blocks of count {0}", blocks.Count));
                        NetworkUtils.SendBlocks([.. blocks], player);
                        blocks.Clear();
                        await Task.Delay(60);
                    }

                    blocks.Add(block.BlockType.GetType().Name);
                    blocks.Add(Utils.PackVector3ToLong(block.Position));
                    blocks.Add(Utils.PackVector3ToLong(block.EulerAngles));
                    blocks.Add(Utils.PackVector3ToLong(block.Size));
                }

                if (blocks.Count > 0)
                {
                    await Task.Delay(60);
                    NetworkUtils.SendBlocks([.. blocks], player);
                }

                return;
            }

            if (data.Code == (int)GorillaCraftNetworkType.SendBlocksCode)
            {
                if (sender.IsLocal) return;

                int minActorNum = NetworkSystem.Instance.AllNetPlayers.Select(netPlayer => netPlayer.ActorNumber).Min();
                int baseActorNum = sender.ActorNumber - minActorNum;
                if (baseActorNum > 0)
                {
                    int delay = baseActorNum * 6;
                    Logging.Info($"Construction delay by {delay} milliseconds ({minActorNum}, {baseActorNum})");
                    await Task.Delay(delay);
                }

                Logging.Info($"Constructing {Mathf.Floor(eventData.Length / 4f)} blocks");

                string blkName = "";
                long blkPos = 0u, blkAngle = 0u, blkSize;

                for (int i = 0; i < eventData.Length; i++)
                {
                    object blkData = eventData[i];

                    Logging.Info(blkData);
                    int blkDataIndex = i % 4;

                    try
                    {
                        switch (blkDataIndex)
                        {
                            case 0:
                                blkName = (string)blkData;
                                break;
                            case 1:
                                blkPos = (long)blkData;
                                break;
                            case 2:
                                blkAngle = (long)blkData;
                                break;
                            case 3:
                                blkSize = (long)blkData;
                                GorillaLocomotion.Player.Instance.GetComponent<BlockHandler>().PlaceBlock(BlockPlaceType.Sent, blkName, Utils.UnpackVector3FromLong(blkPos), Utils.UnpackVector3FromLong(blkAngle), Utils.UnpackVector3FromLong(blkSize), sender, out _, BlockInclusions.None);
                                Logging.Info("Block placed");
                                break;
                        }

                        float progress = Mathf.Round((blkDataIndex + 1) / 4f * 100f);
                        Logging.Info($"Block construction at {progress}%");
                    }
                    catch(Exception ex)
                    {
                        Logging.Error($"Block constructon threw an exception: {ex}");
                        i += 4 - blkDataIndex; // skip this block
                        Logging.Warning("Construction skipped");
                        continue;
                    }
                }
                return;
            }

            Logging.Warning("Howdy! I am your worst enemy.");
        }
    }
}
