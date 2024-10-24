using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class MagentaTerracotta : IBlock
    {
        public BlockFaceInfo Front => new("MagentaTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Left => new("MagentaTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Back => new("MagentaTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Right => new("MagentaTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Top => new("MagentaTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("MagentaTerracotta", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Magenta Terracotta";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
