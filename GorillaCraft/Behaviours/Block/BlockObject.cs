using GorillaCraft.Interfaces;
using GorillaCraft.Tools;
using GorillaExtensions;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GorillaCraft.Behaviours.Block
{
    /// <summary>
    /// BlockObject is a physical object placed by GorillaCraft, with six sides, and a specified owner.
    /// </summary>
    public class BlockObject : MonoBehaviour
    {
        /// <summary>
        /// The owner who is currently in possession of the block.
        /// </summary>
        public NetPlayer Owner;

        /// <summary>
        /// The type of IBlock this block identifies with.
        /// </summary>
        public IBlock BlockType;

        /// <summary>
        /// A <see cref="BlockFace"/>, a physical component given to a face of the block.
        /// </summary>
        public BlockFace Back, Left, Front, Right, Bottom, Top;

        /// <summary>
        /// A list of blocks which currently possess this block (i.e. a block holding up a ladder)
        /// </summary>
        public List<BlockObject> ParentalBlocks = [];

        /// <summary>
        /// A list of blocks which currently are possed by this block (i.e. a ladder)
        /// </summary>
        public List<BlockObject> ChildrenBlocks = [];

        private bool isDestroy;

        public Vector3 Position, EulerAngles, Size;

        /// <summary>
        /// When read, IsLocal will return whether this BlockObject is owned by the local player.
        /// </summary>
        public bool IsLocal => Owner != null && Owner.IsLocal;

        public void Destroy(bool useDestroyEffects = true)
        {
            if (isDestroy) return;
            isDestroy = true;

            try
            {
                // this goes through, we're a parent to one or more children blocks
                if (ChildrenBlocks.Any()) ChildrenBlocks
                        // all children should pass the null check, and should destroy alongside this block
                        .DoIf(block => !block.IsNull(), block => block.Destroy(useDestroyEffects));
                // this goes through, we're a child to preferably a single parent
                else if (ParentalBlocks.Any()) ParentalBlocks
                        // all parents should pass the null & connection check..
                        .Where(block => !block.IsNull() && block.ChildrenBlocks.Any() && block.ChildrenBlocks.Contains(this))
                        // ..and should properly cut ties with this block
                        .Do(block => block.ChildrenBlocks.Remove(this));
            }
            catch (Exception ex)
            {
                Logging.Log(ex, BepInEx.Logging.LogLevel.Error);
            }

            if (useDestroyEffects)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
                UnityEngine.Object.Destroy(gameObject, 5f);
                return;
            }

            UnityEngine.Object.Destroy(gameObject);
        }
    }
}
