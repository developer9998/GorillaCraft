using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class LBTerracotta : IBlock
    {
        public BlockFaceInfo Front => new("LBTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Left => new("LBTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Back => new("LBTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Right => new("LBTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Top => new("LBTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("LBTerracotta", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Light Blue Terracotta";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
