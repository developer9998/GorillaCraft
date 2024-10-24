using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class YellowStainedGlass : IBlock
    {
        public BlockFaceInfo Front => new("YellowSG", typeof(Surface_Default));
        public BlockFaceInfo Left => new("YellowSG", typeof(Surface_Default));
        public BlockFaceInfo Back => new("YellowSG", typeof(Surface_Default));
        public BlockFaceInfo Right => new("YellowSG", typeof(Surface_Default));
        public BlockFaceInfo Top => new("YellowSG", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("YellowSG", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_BreakingGlass);

        public string Definition => "Yellow Stained Glass";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
