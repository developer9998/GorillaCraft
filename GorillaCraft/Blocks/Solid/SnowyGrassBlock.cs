﻿using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class SnowyGrassBlock : IBlock
    {
        public BlockFaceInfo Front => new("SnowGrass", typeof(Surface_Gravel));
        public BlockFaceInfo Left => new("SnowGrass", typeof(Surface_Gravel));
        public BlockFaceInfo Back => new("SnowGrass", typeof(Surface_Gravel));
        public BlockFaceInfo Right => new("SnowGrass", typeof(Surface_Gravel));
        public BlockFaceInfo Top => new("Snow", typeof(Surface_Snow));
        public BlockFaceInfo Bottom => new("Dirt", typeof(Surface_Gravel));

        public Type PlaceSoundType => typeof(Interaction_Grass);
        public Type DestroySoundType => typeof(Interaction_Grass);

        public string BlockDefinition => "Snowy Grass Block";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
