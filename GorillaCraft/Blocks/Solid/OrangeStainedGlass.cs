using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class OrangeStainedGlass : IBlock
    {
        public BlockFaceInfo Front => new("OrangeSG", typeof(Surface_Default));
        public BlockFaceInfo Left => new("OrangeSG", typeof(Surface_Default));
        public BlockFaceInfo Back => new("OrangeSG", typeof(Surface_Default));
        public BlockFaceInfo Right => new("OrangeSG", typeof(Surface_Default));
        public BlockFaceInfo Top => new("OrangeSG", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("OrangeSG", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_BreakingGlass);

        public string Definition => "Orange Stained Glass";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
