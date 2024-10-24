using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class LimeTerracotta : IBlock
    {
        public BlockFaceInfo Front => new("LimeTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Left => new("LimeTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Back => new("LimeTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Right => new("LimeTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Top => new("LimeTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("LimeTerracotta", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Lime Terracotta";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
