﻿using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class LimeWoolBlock : IBlock
    {
        public BlockFaceInfo Front => new("LimeWool", typeof(Surface_Cloth));
        public BlockFaceInfo Left => new("LimeWool", typeof(Surface_Cloth));
        public BlockFaceInfo Back => new("LimeWool", typeof(Surface_Cloth));
        public BlockFaceInfo Right => new("LimeWool", typeof(Surface_Cloth));
        public BlockFaceInfo Top => new("LimeWool", typeof(Surface_Cloth));
        public BlockFaceInfo Bottom => new("LimeWool", typeof(Surface_Cloth));

        public Type PlaceSoundType => typeof(Interaction_Cloth);
        public Type DestroySoundType => typeof(Interaction_Cloth);

        public string BlockDefinition => "Lime Wool";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
