using ExitGames.Client.Photon;
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
    public class PlayerSerializer : MonoBehaviour, IPhotonViewCallback, IOnPhotonViewPreNetDestroy
    {
        public static PlayerSerializer Local;

        private PhotonView View;
        private VRRig Rig;

        private readonly List<BlockGeneralInfo> BlockInfo = new();

        public void Start()
        {
            View = GetComponent<PhotonView>();
            PhotonNetwork.NetworkingClient.EventReceived += OnEvent;

            if (View.IsMine)
            {
                Local = this;
            }
            else
            {
                MultiplayerManager.RequestBlocks(View.Owner);
            }

            Rig = RigCacheUtils.GetField<VRRig>(View.Owner);
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

            var sender = PhotonNetwork.CurrentRoom.GetPlayer(data.Sender);
            var eventData = (object[])data.CustomData;

            if (data.Code == MultiplayerManager.BlockInteractionCode)
            {
                if (sender == View.Owner)
                {
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
                if (sender == View.Owner)
                {
                    Type surfaceType = typeof(Plugin).Assembly.GetTypes().First(type => type.Name == (string)eventData[0]);
                    GorillaLocomotion.Player.Instance.GetComponent<BlockHandler>().PlayTapSound(Rig, surfaceType, (bool)eventData[1]);
                }
            }
            else if (data.Code == MultiplayerManager.RequestBlocksCode)
            {
                if (View.IsMine)
                {
                    Player player = (Player)eventData[0];
                    List<string> blocks = new();

                    foreach (var block in BlockInfo)
                    {
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
                if (sender != View.Owner)
                {
                    string[] blocks = (string[])eventData[0];
                    foreach (string block in blocks)
                    {
                        BlockGeneralInfo blockInfo = JsonConvert.DeserializeObject<BlockGeneralInfo>(block);
                        GorillaLocomotion.Player.Instance.GetComponent<BlockHandler>().PlaceBlock(BlockPlaceType.Recovery, blockInfo.Name, blockInfo.Position, blockInfo.Euler, blockInfo.Scale, sender);
                    }
                }
            }
        }

        public void OnPreNetDestroy(PhotonView rootView)
        {
            if (Local == this)
            {
                Local = null;
            }

            PhotonNetwork.NetworkingClient.EventReceived -= OnEvent;
        }
    }
}
