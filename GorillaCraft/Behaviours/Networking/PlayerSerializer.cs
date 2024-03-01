using ExitGames.Client.Photon;
using GorillaCraft.Extensions;
using GorillaCraft.Interfaces;
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

namespace GorillaCraft.Behaviours.Networking
{
    [DisallowMultipleComponent]
    public class PlayerSerializer : MonoBehaviourPunCallbacks, IPhotonViewCallback, IOnPhotonViewPreNetDestroy
    {
        public static PlayerSerializer Local;
        public bool SharedBlocks;

        private PhotonView View;
        private VRRig Rig;

        private readonly List<BlockGeneralInfo> BlockInfo = new();

        public void Awake()
        {
            BlockInfo.Clear();

            View = GetComponent<PhotonView>();
            Rig = RigCacheUtils.GetField<VRRig>(View.Owner);

            if (View.IsMine)
            {
                Local = this;
            }
            else
            {
                MultiplayerManager.RequestBlocks(View.Owner);
            }
        }

        public void DistributeBlock(bool isCreating, IBlock block, Vector3 blockPosition, Vector3 blockEuler, Vector3 blockScale)
        {
            MultiplayerManager.BlockInteraction(isCreating, block != null ? block.GetType().Name : "None", blockPosition, blockEuler, blockScale);

            if (isCreating)
            {
                BlockInfo.Add(new BlockGeneralInfo()
                {
                    Name = block.GetType().Name,
                    Position = blockPosition,
                    Euler = blockEuler,
                    Scale = blockScale
                });
            }
            else
            {
                BlockGeneralInfo info = BlockInfo.FirstOrDefault(info => info.Position == blockPosition);
                if (info != null)
                {
                    BlockInfo.Remove(info);
                }
            }
        }

        public void OnEvent(EventData data)
        {
            if (data.Code != MultiplayerManager.BlockInteractionCode && data.Code != MultiplayerManager.SurfaceTapCode && data.Code != MultiplayerManager.RequestBlocksCode && data.Code != MultiplayerManager.SendBlocksCode) return;

            Player sender = PhotonNetwork.CurrentRoom.GetPlayer(data.Sender);
            object[] eventData = (object[])data.CustomData;

            if (sender == null || !sender.InRoom())
            {
                Logging.Log("OnEvent Error: The event was sent by a null player or of one not in this room", BepInEx.Logging.LogLevel.Error);
                return;
            }

            if (data.Code == MultiplayerManager.BlockInteractionCode)
            {
                Logging.Log(string.Concat("BlockInteractionCode: ", sender.ToString()));
                if (sender == View.Owner)
                {
                    Logging.Log("BlockInteractionCode is a valid event");
                    if ((bool)eventData[0])
                    {
                        GorillaLocomotion.Player.Instance.GetComponent<BlockHandler>().PlaceBlock(BlockPlaceType.Server, (string)eventData[1], (Vector3)eventData[2], (Vector3)eventData[3], (Vector3)eventData[4], View.Owner);
                    }
                    else
                    {
                        GorillaLocomotion.Player.Instance.GetComponent<BlockHandler>().RemoveBlock((Vector3)eventData[2], View.Owner);
                    }
                }
            }
            else if (data.Code == MultiplayerManager.SurfaceTapCode)
            {
                Logging.Log(string.Concat("SurfaceTapCode: ", sender.ToString()));
                if (sender == View.Owner)
                {
                    Logging.Log("SurfaceTapCode is a valid event");
                    Type surfaceType = typeof(Plugin).Assembly.GetTypes().First(type => type.Name == (string)eventData[0]);
                    GorillaLocomotion.Player.Instance.GetComponent<BlockHandler>().PlayTapSound(Rig, surfaceType, (bool)eventData[1]);
                }
            }
            else if (data.Code == MultiplayerManager.RequestBlocksCode)
            {
                Logging.Log(string.Concat("RequestBlocksCode: ", sender.ToString()));
                if (View.Owner.InRoom() && View.Owner.IsLocal)
                {
                    Logging.Log("RequestBlocksCode is a valid event");
                    Player player = (Player)eventData[0];
                    List<string> blocks = new();

                    foreach (var block in BlockInfo)
                    {
                        Logging.Log(block.Name);
                        if (blocks.Count >= 8)
                        {
                            MultiplayerManager.SendBlocks(blocks.ToArray(), player);
                            blocks.Clear();
                        }

                        blocks.Add(JsonConvert.SerializeObject(block, Formatting.None));
                    }

                    if (blocks.Count > 0)
                    {
                        MultiplayerManager.SendBlocks(blocks.ToArray(), player);
                    }
                }
            }
            else if (data.Code == MultiplayerManager.SendBlocksCode)
            {
                Logging.Log(string.Concat("SendBlocksCode: ", sender.ToString()));
                if (sender != View.Owner)
                {
                    Logging.Log("SendBlocksCode is a valid event");
                    string[] blocks = (string[])eventData[0];
                    foreach (string block in blocks)
                    {
                        BlockGeneralInfo blockInfo = JsonConvert.DeserializeObject<BlockGeneralInfo>(block);
                        GorillaLocomotion.Player.Instance.GetComponent<BlockHandler>().PlaceBlock(BlockPlaceType.Recovery, blockInfo.Name, blockInfo.Position, blockInfo.Euler, blockInfo.Scale, sender);
                    }
                }
            }
        }

        public new void OnEnable()
        {
            PhotonNetwork.NetworkingClient.EventReceived += OnEvent;
        }

        public new void OnDisable()
        {
            PhotonNetwork.NetworkingClient.EventReceived -= OnEvent;
        }

        public void OnPreNetDestroy(PhotonView rootView)
        {
            if (Local == this)
            {
                Local = null;
            }
        }

    }
}
