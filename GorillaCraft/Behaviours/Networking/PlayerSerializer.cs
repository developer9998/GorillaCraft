using GorillaCraft.Extensions;
using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Tools;
using GorillaCraft.Utilities;
using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GorillaCraft.Behaviours.Networking
{
    // TODO: relocate into one component, not attached to any photonviews

    [RequireComponent(typeof(PhotonView)), DisallowMultipleComponent]
    public class PlayerSerializer : MonoBehaviourPunCallbacks, IPhotonViewCallback
    {
        public static PlayerSerializer Local;

        public readonly List<BlockData> BlockInfo = [];

        //private PhotonView View;

        public void Awake()
        {
            try
            {
                BlockInfo.Clear();

                var rigView = GetComponent<VRRig>();
                if (rigView.Creator.IsLocal)
                {
                    Local = this;
                }
                else
                {
                    NetworkUtils.RequestBlocks(PhotonNetwork.CurrentRoom.GetPlayer(rigView.Creator.ActorNumber));
                }
            }
            catch (Exception exception)
            {
                Logging.Log(exception.String(), BepInEx.Logging.LogLevel.Error);
            }
        }

        public new void OnDisable()
        {
            if (Local == this)
            {
                Local = null;
            }
            Destroy(this);
        }

        public void DistributeBlock(bool isCreating, IBlock block, Vector3 blockPosition, Vector3 blockEuler, Vector3 blockScale)
        {
            try
            {
                NetworkUtils.BlockInteraction(isCreating, block != null ? block.GetType().Name : "None", blockPosition, blockEuler, blockScale);

                if (isCreating)
                {
                    BlockInfo.Add(new BlockData()
                    {
                        Name = block.GetType().Name,
                        Position = (BlockPosition)blockPosition,
                        Euler = (BlockPosition)blockEuler,
                        Scale = (BlockPosition)blockScale
                    });
                }
                else
                {
                    BlockData info = BlockInfo.FirstOrDefault(info => info.Position == blockPosition);
                    if (info != null)
                    {
                        BlockInfo.Remove(info);
                    }
                }
            }
            catch (Exception exception)
            {
                Logging.Log(exception.String(), BepInEx.Logging.LogLevel.Error);
            }
        }
    }
}
