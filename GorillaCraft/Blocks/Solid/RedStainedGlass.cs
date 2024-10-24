using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class RedStainedGlass : IBlock
    {
        public BlockFaceInfo Front => new("RedSG", typeof(Surface_Default));
        public BlockFaceInfo Left => new("RedSG", typeof(Surface_Default));
        public BlockFaceInfo Back => new("RedSG", typeof(Surface_Default));
        public BlockFaceInfo Right => new("RedSG", typeof(Surface_Default));
        public BlockFaceInfo Top => new("RedSG", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("RedSG", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_BreakingGlass);

        public string Definition => "Red Stained Glass";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
