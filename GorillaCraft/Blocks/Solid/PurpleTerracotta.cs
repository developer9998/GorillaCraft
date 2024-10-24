using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class PurpleTerracotta : IBlock
    {
        public BlockFaceInfo Front => new("PurpleTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Left => new("PurpleTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Back => new("PurpleTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Right => new("PurpleTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Top => new("PurpleTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("PurpleTerracotta", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Purple Terracotta";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
