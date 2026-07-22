using GorillaCraft.Models;
using System.Collections.Generic;
using UnityEngine;

namespace GorillaCraft.Behaviours.Blocks
{
    /// <summary>
    /// BlockFace is a physical object which is a part of a root <see cref="Block"/>.
    /// </summary>
    public class BlockFace : MonoBehaviour
    {
        /// <summary>
        /// The <see cref="Block"/> which possesses this face.
        /// </summary>
        public Block Root;

        public BlockFaceObject FaceObject;

        public List<Block> ChildBlocks = [];
    }
}
