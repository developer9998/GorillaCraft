using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class BlueTerracotta : IBlock
    {
        public BlockFaceInfo Front => new("BlueTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Left => new("BlueTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Back => new("BlueTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Right => new("BlueTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Top => new("BlueTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("BlueTerracotta", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Blue Terracotta";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
