using GorillaCraft.Models;
using System;

namespace GorillaCraft.Interfaces
{
    public interface IBlock
    {
        public string Definition { get; }

        public BlockFaceInfo Front { get; }
        public BlockFaceInfo Left { get; }
        public BlockFaceInfo Back { get; }
        public BlockFaceInfo Right { get; }
        public BlockFaceInfo Top { get; }
        public BlockFaceInfo Bottom { get; }

        public Type PlaceSound { get; }
        public Type BreakSound { get; }

        public BlockForm Form { get; }
        public BlockPlacement Placement { get; }
    }
}
