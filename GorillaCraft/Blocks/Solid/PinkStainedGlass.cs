using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class PinkStainedGlass : IBlock
    {
        public BlockFaceInfo Front => new("PinkSG", typeof(Surface_Default));
        public BlockFaceInfo Left => new("PinkSG", typeof(Surface_Default));
        public BlockFaceInfo Back => new("PinkSG", typeof(Surface_Default));
        public BlockFaceInfo Right => new("PinkSG", typeof(Surface_Default));
        public BlockFaceInfo Top => new("PinkSG", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("PinkSG", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_BreakingGlass);

        public string Definition => "Pink Stained Glass";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
