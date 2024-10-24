using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class BlackStainedGlass : IBlock
    {
        public BlockFaceInfo Front => new("BlackSG", typeof(Surface_Default));
        public BlockFaceInfo Left => new("BlackSG", typeof(Surface_Default));
        public BlockFaceInfo Back => new("BlackSG", typeof(Surface_Default));
        public BlockFaceInfo Right => new("BlackSG", typeof(Surface_Default));
        public BlockFaceInfo Top => new("BlackSG", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("BlackSG", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_BreakingGlass);

        public string Definition => "Black Stained Glass";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
