﻿using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Nonsolid
{
    public class AzureBlock : IBlock
    {
        public BlockFaceInfo Front => new("Azure Bluet", typeof(Surface_Grass));
        public BlockFaceInfo Left => new("Azure Bluet", typeof(Surface_Grass));
        public BlockFaceInfo Back => new("Azure Bluet", typeof(Surface_Grass));
        public BlockFaceInfo Right => new("Azure Bluet", typeof(Surface_Grass));
        public BlockFaceInfo Top => new("Azure Bluet", typeof(Surface_Grass));
        public BlockFaceInfo Bottom => new("Azure Bluet", typeof(Surface_Grass));

        public Type PlaceSound => typeof(Interaction_Grass);
        public Type BreakSound => typeof(Interaction_Grass);

        public string Definition => "Azure Bluet";
        public BlockForm Form => BlockForm.Decoration;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
