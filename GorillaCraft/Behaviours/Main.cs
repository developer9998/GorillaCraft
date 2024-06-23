using ExitGames.Client.Photon;
using GorillaCraft.Behaviours.Networking;
using GorillaCraft.Behaviours.UI;
using GorillaCraft.Extensions;
using GorillaCraft.Models;
using GorillaCraft.Tools;
using GorillaCraft.Utilities;
using Newtonsoft.Json;
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
        }

        public override void OnLeftRoom()
        {
            base.OnLeftRoom();
            PhotonNetwork.NetworkingClient.EventReceived -= OnEvent;
        }

        public async void OnEvent(EventData data)
        {
            if (data.Code != NetworkSender.BlockInteractionCode && data.Code != NetworkSender.SurfaceTapCode && data.Code != NetworkSender.RequestBlocksCode && data.Code != NetworkSender.SendBlocksCode) return;

            Player sender = PhotonNetwork.CurrentRoom.GetPlayer(data.Sender);
            object[] eventData = (object[])data.CustomData;

            if (data.Code == NetworkSender.BlockInteractionCode)
            {
                PhotonView photonView = RigCacheUtils.GetProperty<PhotonView>(sender);
                if (photonView)
                {
                    if ((bool)eventData[0])
                    {
                        GorillaLocomotion.Player.Instance.GetComponent<BlockHandler>().PlaceBlock(BlockPlaceType.Server, (string)eventData[1], (Vector3)eventData[2], (Vector3)eventData[3], (Vector3)eventData[4], photonView.Owner, out _, BlockInclusions.Audio);
                    }
                    else
                    {
                        GorillaLocomotion.Player.Instance.GetComponent<BlockHandler>().RemoveBlock((Vector3)eventData[2], photonView.Owner);
                    }
                }
                else
                {
                    Logging.Log(string.Concat(data.String(), "- This event is void"));
                }
            }
            else if (data.Code == NetworkSender.SurfaceTapCode)
            {
                PhotonView photonView = RigCacheUtils.GetProperty<PhotonView>(sender);
                if (photonView)
                {

                    Type surfaceType = typeof(Plugin).Assembly.GetTypes().First(type => type.Name == (string)eventData[0]);
                    GorillaLocomotion.Player.Instance.GetComponent<BlockHandler>().PlayTapSound(RigCacheUtils.GetProperty<VRRig>(sender), surfaceType, (bool)eventData[1]);
                }
                else
                {
                    Logging.Log(string.Concat(data.String(), "- This event is void"));
                }
            }
            else if (data.Code == NetworkSender.RequestBlocksCode)
            {
                if (!sender.IsLocal)
                {
                    Logging.Log(string.Concat(data.String(), "- rq This event is validated"));

                    try
                    {
                        Player player = (Player)eventData[0];
                        List<string> blocks = [];

                        foreach (var block in PlayerSerializer.Local.BlockInfo)
                        {
                            if (blocks.Count >= 10)
                            {
                                Logging.Log(string.Format("Sending current list of blocks of count {0}", blocks.Count));
                                NetworkSender.SendBlocks([.. blocks], player);
                                blocks.Clear();
                                await Task.Delay(50);
                            }

                            try
                            {
                                string json = JsonConvert.SerializeObject(block, Formatting.None);
                                blocks.Add(json);
                            }
                            catch (Exception e)
                            {
                                Logging.Log(string.Format("Error when serializing block {0}: {1}", block.ToString(), e.String()));
                            }
                        }

                        if (blocks.Count > 0)
                        {
                            await Task.Delay(50);

                            Logging.Log("Sending remaining blocks");
                            NetworkSender.SendBlocks([.. blocks], player);
                        }
                    }
                    catch (Exception e)
                    {
                        Logging.Log(string.Format("Error when processing SendBlocksCode - {0}", e.String()), BepInEx.Logging.LogLevel.Error);
                    }
                }
                else
                {
                    Logging.Log(string.Concat(data.String(), "- rq This event is void"));
                }
            }
            else if (data.Code == NetworkSender.SendBlocksCode)
            {
                if (!sender.IsLocal)
                {
                    try
                    {
                        Logging.Log(string.Concat(data.String(), "- sd This event is validated"));

                        string[] blocks = (string[])eventData[0];
                        foreach (string block in blocks)
                        {
                            Logging.Log(string.Format("Received block from {0}:\n{1}", sender.ToString(), block));

                            BlockData blockInfo = JsonConvert.DeserializeObject<BlockData>(block);

                            GorillaLocomotion.Player.Instance.GetComponent<BlockHandler>().PlaceBlock(BlockPlaceType.Recovery, blockInfo.Name, blockInfo.Position, blockInfo.Euler, blockInfo.Scale, sender, out _, BlockInclusions.None);
                        }
                    }
                    catch (Exception e)
                    {
                        Logging.Log(string.Format("Error when processing SendBlocksCode - {0}", e.String()), BepInEx.Logging.LogLevel.Error);
                    }
                }
                else
                {
                    Logging.Log(string.Concat(data.String(), "- sd This event is void"));
                }
            }
        }
    }
}
