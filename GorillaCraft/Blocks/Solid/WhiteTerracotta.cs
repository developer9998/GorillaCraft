using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class WhiteTerracotta : IBlock
    {
        public BlockFaceInfo Front => new("WhiteTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Left => new("WhiteTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Back => new("WhiteTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Right => new("WhiteTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Top => new("WhiteTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("WhiteTerracotta", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "White Terracotta";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
