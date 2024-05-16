using System;

namespace GorillaCraft.Models
{
    /// <summary>
    /// BlockData is serialized data often used when transferring data easily through Photon.
    /// </summary>
    [Serializable]
    public class BlockData
    {
        /// <summary>
        /// The name of the class which represents this block.
        /// </summary>
        public string Name;

        /// <summary>
        /// The position given to the block.
        /// </summary>
        public BlockPosition Position;

        /// <summary>
        /// The rotation (aka. euler) given to the block.
        /// </summary>
        public BlockPosition Euler;

        /// <summary>
        /// The scale given to the block. TODO: Replace with a singular float
        /// </summary>
        public BlockPosition Scale;

        public override string ToString() => string.Format("'{0}' [{1}, {2}, {3}], [{4}, {5}, {6}], [{7}, {8}, {9}]", Name, Position.x, Position.y, Position.z, Euler.x, Euler.y, Euler.z, Scale.x, Scale.y, Scale.z);
    }
}
