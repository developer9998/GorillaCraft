using GorillaCraft.Models;
using System;

namespace GorillaCraft.Interfaces
{
    public interface IBlock
    {
        public BlockFaceInfo Front { get; }
        public BlockFaceInfo Left { get; }
        public BlockFaceInfo Back { get; }
        public BlockFaceInfo Right { get; }
        public BlockFaceInfo Up { get; }
        public BlockFaceInfo Down { get; }

        public Type PlaceSoundType { get; }
        public Type DestroySoundType { get; }

        public string BlockDefinition { get; }
        public BlockBehaviourType BlockType { get; }
    }
}
