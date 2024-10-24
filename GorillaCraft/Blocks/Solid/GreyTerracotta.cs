using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class GreyTerracotta : IBlock
    {
        public BlockFaceInfo Front => new("GreyTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Left => new("GreyTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Back => new("GreyTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Right => new("GreyTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Top => new("GreyTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("GreyTerracotta", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Grey Terracotta";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
