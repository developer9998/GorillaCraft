using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class WhiteStainedGlass : IBlock
    {
        public BlockFaceInfo Front => new("WhiteSG", typeof(Surface_Default));
        public BlockFaceInfo Left => new("WhiteSG", typeof(Surface_Default));
        public BlockFaceInfo Back => new("WhiteSG", typeof(Surface_Default));
        public BlockFaceInfo Right => new("WhiteSG", typeof(Surface_Default));
        public BlockFaceInfo Top => new("WhiteSG", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("WhiteSG", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_BreakingGlass);

        public string Definition => "White Stained Glass";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
