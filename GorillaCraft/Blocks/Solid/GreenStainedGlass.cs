using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class GreenStainedGlass : IBlock
    {
        public BlockFaceInfo Front => new("GreenSG", typeof(Surface_Default));
        public BlockFaceInfo Left => new("GreenSG", typeof(Surface_Default));
        public BlockFaceInfo Back => new("GreenSG", typeof(Surface_Default));
        public BlockFaceInfo Right => new("GreenSG", typeof(Surface_Default));
        public BlockFaceInfo Top => new("GreenSG", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("GreenSG", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_BreakingGlass);

        public string Definition => "Green Stained Glass";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
