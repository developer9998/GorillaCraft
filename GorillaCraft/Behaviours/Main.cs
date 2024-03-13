using ExitGames.Client.Photon;
using GorillaCraft.Behaviours.Networking;
using GorillaCraft.Behaviours.UI.GamemodeMenu;
using GorillaCraft.Behaviours.UI.SelectionMenu;
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
using UnityEngine;
using Zenject;

namespace GorillaCraft.Behaviours
{
    public class Main : MonoBehaviour, IInitializable
    {
        internal bool isActivated;

        private PlacementHelper PlacementHelper;
        private AssetLoader AssetLoader;

        private MenuHandler MenuHandler;
        private ModeMenuHandler MenuHandler_Mode;

        private bool ModeBindActivated;

        [Inject]
        public void Construct(PlacementHelper placementHelper, AssetLoader assetLoader)
        {
            PlacementHelper = placementHelper;
            AssetLoader = assetLoader;
        }

        public async void Initialize()
        {
            Plugin.Allowed.AddCallback(OnRoomEntered);

            await AssetLoader.LoadAsset<GameObject>("ItemSelector");
            await AssetLoader.LoadAsset<GameObject>("GamemodeSelector");
            await AssetLoader.LoadAsset<Sprite>("slot");
            await AssetLoader.LoadAsset<Sprite>("selection");

            GameObject itemSelectionMenu = Instantiate(await AssetLoader.LoadAsset<GameObject>("ItemSelector"));
            itemSelectionMenu.transform.SetParent(GorillaTagger.Instance.offlineVRRig.leftHandTransform.parent);

            MenuHandler = itemSelectionMenu.AddComponent<MenuHandler>();
            MenuHandler._placementHelper = PlacementHelper;

            GameObject modeSelectionMenu = Instantiate(await AssetLoader.LoadAsset<GameObject>("GamemodeSelector"));
            modeSelectionMenu.transform.SetParent(GorillaTagger.Instance.offlineVRRig.leftHandTransform.parent);
            modeSelectionMenu.SetActive(false); // Hide this, it's not needed right now

            MenuHandler_Mode = modeSelectionMenu.AddComponent<ModeMenuHandler>();
            MenuHandler_Mode._offSprite = await AssetLoader.LoadAsset<Sprite>("slot");
            MenuHandler_Mode._onSprite = await AssetLoader.LoadAsset<Sprite>("selection");
            MenuHandler_Mode._placementHelper = PlacementHelper;

            PhotonNetwork.NetworkingClient.EventReceived += OnEvent;
        }

        public void Update()
        {
            if (!MenuHandler_Mode || !MenuHandler) return;

            if (!isActivated)
            {
                MenuHandler_Mode.gameObject.SetActive(false);
                MenuHandler.gameObject.SetActive(false);
                return;
            }

            bool buttonHeld = ControllerInputPoller.instance.leftControllerPrimaryButton;
            if (buttonHeld && buttonHeld != ModeBindActivated)
            {
                MenuHandler_Mode.gameObject.SetActive(true);
                MenuHandler.gameObject.SetActive(false);
            }
            else if (!buttonHeld && buttonHeld != ModeBindActivated)
            {
                MenuHandler_Mode.gameObject.SetActive(false);
                MenuHandler.gameObject.SetActive(PlacementHelper.Mode != 2);
            }
            ModeBindActivated = buttonHeld;
        }

        private void OnRoomEntered(bool state)
        {
            isActivated = state;
            if (isActivated)
            {
                MenuHandler.gameObject.SetActive(PlacementHelper.Mode != 2);
            }
            else
            {
                MenuHandler_Mode.gameObject.SetActive(false);
                MenuHandler.gameObject.SetActive(false);
            }
        }

        public void OnEvent(EventData data)
        {
            if (data.Code != NetworkSender.BlockInteractionCode && data.Code != NetworkSender.SurfaceTapCode && data.Code != NetworkSender.RequestBlocksCode && data.Code != NetworkSender.SendBlocksCode) return;

            Player sender = PhotonNetwork.CurrentRoom.GetPlayer(data.Sender);
            object[] eventData = (object[])data.CustomData;

            if (data.Code == NetworkSender.BlockInteractionCode)
            {
                PhotonView photonView = RigCacheUtils.GetProperty<PhotonView>(sender);
                if (photonView)
                {
                    Logging.Log(string.Concat(data.String(), "- This event is validated"));

                    if ((bool)eventData[0])
                    {
                        GorillaLocomotion.Player.Instance.GetComponent<BlockHandler>().PlaceBlock(BlockPlaceType.Server, (string)eventData[1], (Vector3)eventData[2], (Vector3)eventData[3], (Vector3)eventData[4], photonView.Owner, out _);
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
                    Logging.Log(string.Concat(data.String(), "- This event is validated"));

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
                    Logging.Log(string.Concat(data.String(), "- This event is validated"));

                    Player player = (Player)eventData[0];
                    List<string> blocks = new();

                    foreach (var block in PlayerSerializer.Local.BlockInfo)
                    {
                        Logging.Log(block.Name);
                        if (blocks.Count >= 8)
                        {
                            NetworkSender.SendBlocks(blocks.ToArray(), player);
                            blocks.Clear();
                        }

                        blocks.Add(JsonConvert.SerializeObject(block, Formatting.None));
                    }

                    if (blocks.Count > 0)
                    {
                        NetworkSender.SendBlocks(blocks.ToArray(), player);
                    }
                }
                else
                {
                    Logging.Log(string.Concat(data.String(), "- This event is void"));
                }
            }
            else if (data.Code == NetworkSender.SendBlocksCode)
            {
                if (!sender.IsLocal)
                {
                    Logging.Log(string.Concat(data.String(), "- This event is validated"));

                    string[] blocks = (string[])eventData[0];
                    foreach (string block in blocks)
                    {
                        BlockGeneralInfo blockInfo = JsonConvert.DeserializeObject<BlockGeneralInfo>(block);
                        GorillaLocomotion.Player.Instance.GetComponent<BlockHandler>().PlaceBlock(BlockPlaceType.Recovery, blockInfo.Name, blockInfo.Position, blockInfo.Euler, blockInfo.Scale, sender, out _);
                    }
                }
                else
                {
                    Logging.Log(string.Concat(data.String(), "- This event is void"));
                }
            }
        }
    }
}
