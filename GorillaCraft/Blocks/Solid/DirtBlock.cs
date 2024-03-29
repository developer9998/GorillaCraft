﻿using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class DirtBlock : IBlock
    {
        public BlockFaceInfo Front => new("Dirt", typeof(Surface_Gravel));
        public BlockFaceInfo Left => new("Dirt", typeof(Surface_Gravel));
        public BlockFaceInfo Back => new("Dirt", typeof(Surface_Gravel));
        public BlockFaceInfo Right => new("Dirt", typeof(Surface_Gravel));
        public BlockFaceInfo Top => new("Dirt", typeof(Surface_Gravel));
        public BlockFaceInfo Bottom => new("Dirt", typeof(Surface_Gravel));

        public Type PlaceSoundType => typeof(Interaction_Gravel);
        public Type DestroySoundType => typeof(Interaction_Gravel);

        public string BlockDefinition => "Dirt";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
