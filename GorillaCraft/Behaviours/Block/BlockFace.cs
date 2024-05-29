using GorillaCraft.Sounds;
using System;
using UnityEngine;

namespace GorillaCraft.Behaviours.Block
{
    /// <summary>
    /// BlockFace is a physical object which is a part of a root <see cref="BlockObject"/>.
    /// </summary>
    public class BlockFace : MonoBehaviour
    {
        /// <summary>
        /// The <see cref="BlockObject"/> which possesses this face.
        /// </summary>
        public BlockObject Root;

        /// <summary>
        /// The IDataType type of the face. (i.e. <see cref="Surface_Default"/> 
        /// </summary>
        public Type SurfaceType;
    }
}
