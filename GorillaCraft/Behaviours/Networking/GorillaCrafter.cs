using GorillaCraft.Behaviours.Block;
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
        public bool HasGorillaCraft => Creator.GetPlayerRef().CustomProperties.ContainsKey("GC");

        public readonly Dictionary<long, BlockObject> Blocks = [];

        private RigContainer rigContainer;

        public void Awake()
        {
            rigContainer = GetComponent<RigContainer>();

            if (!rigContainer)
            {
                Destroy(this);
                return;
            }
        }

        public void Start()
        {
            //                                   Nickname              IsLocal               HasGorillaCraft
            Logging.Info($"GorillaCrafter Start (N: {Creator.NickName} IL: {Creator.IsLocal} HGC: {HasGorillaCraft}");

            if (Local == null && Creator.IsLocal)
            {
                Local = this;
                return;
            }
            else if (Local != this && Creator.IsLocal)
            {
                Destroy(Local);
                Local = this;
                return;
            }

            if (HasGorillaCraft)
            {
                NetworkUtility.RequestBlocks(Creator.GetPlayerRef());
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
                long blockPosition = Utils.PackVector3ToLong(block.Position);

                if (isCreating)
                {
                    Blocks.Add(blockPosition, block);

                    if (Creator.IsLocal)
                    {
                        long blockEulerAngles = Utils.PackVector3ToLong(block.EulerAngles);
                        long blockScale = Utils.PackVector3ToLong(block.Size);
                        NetworkUtility.BlockInteraction(true, block.BlockType.GetType().Name, blockPosition, blockEulerAngles, blockScale);
                    }

                }
                else if (Blocks.TryGetValue(blockPosition, out var lookupBlock))
                {
                    Blocks.Remove(blockPosition);
                    if (Creator.IsLocal)
                    {
                        NetworkUtility.BlockInteraction(false, blockPosition);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.Error($"{nameof(DistributeBlock)} threw an exception {ex}");
            }
        }
    }
}
