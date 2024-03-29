﻿using GorillaCraft.Models;
using System;

namespace GorillaCraft.Interfaces
{
    public interface IBlock
    {
        public string BlockDefinition { get; }

        public BlockFaceInfo Front { get; }
        public BlockFaceInfo Left { get; }
        public BlockFaceInfo Back { get; }
        public BlockFaceInfo Right { get; }
        public BlockFaceInfo Top { get; }
        public BlockFaceInfo Bottom { get; }

        public Type PlaceSoundType { get; }
        public Type DestroySoundType { get; }

        public BlockForm BlockForm { get; }
        public BlockPlacement BlockPlacement { get; }
    }
}
