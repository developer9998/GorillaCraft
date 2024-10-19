using GorillaCraft.Behaviours.Block;
using GorillaCraft.Extensions;
using GorillaCraft.Tools;
using GorillaCraft.Utilities;
using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GorillaCraft.Behaviours.Networking
{

    [DisallowMultipleComponent]
    public class GorillaCrafter : MonoBehaviourPunCallbacks, IPhotonViewCallback
    {
        public static GorillaCrafter Local;

        public NetPlayer Creator => rigContainer.Creator;

        public readonly Dictionary<long, BlockObject> Blocks = [];

        private bool hasGorillaCraft;

        private RigContainer rigContainer;

        public void Start()
        {
            rigContainer = GetComponent<RigContainer>();
            if (!rigContainer)
            {
                Destroy(this);
                return;
            }

            hasGorillaCraft = Creator.GetPlayerRef().CustomProperties.ContainsKey("GC");

            if (Creator.IsLocal)
            {
                Local = this;
            }
            else
            {
                NetworkUtils.RequestBlocks(PhotonNetwork.CurrentRoom.GetPlayer(Creator.ActorNumber));
            }
        }

        public void OnDestroy()
        {
            if (Local == this)
            {
                Local = null;
            }

            for (int i = 0; i < Blocks.Count; i++)
            {
                var block = Blocks.Values.ElementAt(i);
                block.Destroy(false);
            }

            Blocks.Clear();

            Destroy(this);
        }

        public void DistributeBlock(bool isCreating, BlockObject block)
        {
            try
            {
                long blockPosition = Utils.PackVector3ToLong(block.transform.position);

                if (isCreating)
                {
                    Blocks.Add(blockPosition, block);

                    if (Creator.IsLocal)
                    {
                        long blockEulerAngles = Utils.PackVector3ToLong(block.transform.eulerAngles);
                        long blockScale = Utils.PackVector3ToLong(block.transform.localScale);
                        NetworkUtils.BlockInteraction(true, block.BlockType.GetType().Name, blockPosition, blockEulerAngles, blockScale);
                    }

                }
                else if (Blocks.TryGetValue(blockPosition, out var lookupBlock))
                {
                    Blocks.Remove(blockPosition);
                    if (Creator.IsLocal)
                    {
                        NetworkUtils.BlockInteraction(false, blockPosition);
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
