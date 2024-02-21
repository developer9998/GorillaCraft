using GorillaCraft.Interfaces;
using GorillaCraft.Models;
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
    public class PlayerSerializer : MonoBehaviourPun
    {
        public static PlayerSerializer Local;

        private VRRig Rig;
        private readonly List<BlockGeneralInfo> BlockInfo = new();

        public void Start()
        {
            if (photonView.IsMine)
            {
                Local = this;
            }
            else
            {
                photonView.RPC(nameof(RequestBlocks), photonView.Owner, PhotonNetwork.LocalPlayer);
            }

            Rig = RigCacheUtils.GetField<VRRig>(photonView.Owner);
        }

        public void OnDestroy()
        {
            if (Local == this)
            {
                Local = null;
            }
        }

        public void HandleBlock(bool isCreating, GameObject blockObject, IBlock block, Vector3 blockPosition, Vector3 blockEuler, Vector3 blockScale)
        {
            photonView.RPC(nameof(ServerIndividualBlock), RpcTarget.Others, isCreating, block != null ? block.GetType().Name : "None", blockPosition, blockEuler, blockScale);

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

        private void ReplaceMatch(ref List<string> list, string original, string sub)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == original)
                {
                    list[i] = sub;
                    break;
                }
            }
        }

        [PunRPC]
        public void RequestBlocks(Player player, PhotonMessageInfo info)
        {
            if (photonView.IsMine)
            {
                List<string> blocks = new()
                {
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty
                };

                foreach (var block in BlockInfo)
                {
                    if (blocks.Any(a => a == string.Empty))
                    {
                        ReplaceMatch(ref blocks, string.Empty, JsonConvert.SerializeObject(block, Formatting.None));
                        continue;
                    }

                    photonView.RPC(nameof(ServerRecoverBlock), player, blocks[0], blocks[1], blocks[2], blocks[3]);
                    blocks = new()
                    {
                        string.Empty,
                        string.Empty,
                        string.Empty,
                        string.Empty
                    };
                }

                if (blocks.Any(a => a == string.Empty))
                {
                    photonView.RPC(nameof(ServerRecoverBlock), player, blocks[0], blocks[1], blocks[2], blocks[3]);
                }
            }
        }

        [PunRPC]
        public void ServerRecoverBlock(string block1, string block2, string block3, string block4, PhotonMessageInfo info)
        {
            if (info.photonView.Owner == info.Sender)
            {
                if (block1 != string.Empty)
                {
                    BlockGeneralInfo blockInfo = JsonConvert.DeserializeObject<BlockGeneralInfo>(block1);
                    GorillaLocomotion.Player.Instance.GetComponent<BlockHandler>().PlaceBlock(BlockPlaceType.Recovery, blockInfo.Name, blockInfo.Position, blockInfo.Euler, blockInfo.Scale, info.Sender);
                }

                if (block2 != string.Empty)
                {
                    BlockGeneralInfo blockInfo = JsonConvert.DeserializeObject<BlockGeneralInfo>(block2);
                    GorillaLocomotion.Player.Instance.GetComponent<BlockHandler>().PlaceBlock(BlockPlaceType.Recovery, blockInfo.Name, blockInfo.Position, blockInfo.Euler, blockInfo.Scale, info.Sender);
                }

                if (block3 != string.Empty)
                {
                    BlockGeneralInfo blockInfo = JsonConvert.DeserializeObject<BlockGeneralInfo>(block3);
                    GorillaLocomotion.Player.Instance.GetComponent<BlockHandler>().PlaceBlock(BlockPlaceType.Recovery, blockInfo.Name, blockInfo.Position, blockInfo.Euler, blockInfo.Scale, info.Sender);
                }

                if (block4 != string.Empty)
                {
                    BlockGeneralInfo blockInfo = JsonConvert.DeserializeObject<BlockGeneralInfo>(block4);
                    GorillaLocomotion.Player.Instance.GetComponent<BlockHandler>().PlaceBlock(BlockPlaceType.Recovery, blockInfo.Name, blockInfo.Position, blockInfo.Euler, blockInfo.Scale, info.Sender);
                }
            }
        }

        [PunRPC]
        public void ServerIndividualBlock(bool isCreating, string block, Vector3 blockPosition, Vector3 blockEuler, Vector3 blockScale, PhotonMessageInfo info)
        {
            if (info.photonView.Owner == info.Sender)
            {
                if (isCreating)
                {
                    GorillaLocomotion.Player.Instance.GetComponent<BlockHandler>().PlaceBlock(BlockPlaceType.Server, block, blockPosition, blockEuler, blockScale, photonView.Owner);
                    return;
                }

                GorillaLocomotion.Player.Instance.GetComponent<BlockHandler>().RemoveBlock(blockPosition, photonView.Owner);
            }
        }

        [PunRPC]
        public void PlaySurfaceType(string typeName, bool isLeftHand, PhotonMessageInfo info)
        {
            if (info.Sender == photonView.Owner)
            {
                Type surfaceType = typeof(Plugin).Assembly.GetTypes().First(type => type.Name == typeName);
                GorillaLocomotion.Player.Instance.GetComponent<BlockHandler>().PlayTapSound(Rig, surfaceType, isLeftHand);
            }
        }
    }
}
