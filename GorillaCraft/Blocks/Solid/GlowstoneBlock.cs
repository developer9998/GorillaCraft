using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class GlowstoneBlock : IBlock
    {
        public BlockFaceInfo Front => new("Glowstone", typeof(Surface_Default));
        public BlockFaceInfo Left => new("Glowstone", typeof(Surface_Default));
        public BlockFaceInfo Back => new("Glowstone", typeof(Surface_Default));
        public BlockFaceInfo Right => new("Glowstone", typeof(Surface_Default));
        public BlockFaceInfo Top => new("Glowstone", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("Glowstone", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_BreakingGlass);

        public string Definition => "Glowstone";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
