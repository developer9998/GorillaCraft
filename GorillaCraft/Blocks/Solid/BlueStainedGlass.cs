using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class BlueStainedGlass : IBlock
    {
        public BlockFaceInfo Front => new("BlueSG", typeof(Surface_Default));
        public BlockFaceInfo Left => new("BlueSG", typeof(Surface_Default));
        public BlockFaceInfo Back => new("BlueSG", typeof(Surface_Default));
        public BlockFaceInfo Right => new("BlueSG", typeof(Surface_Default));
        public BlockFaceInfo Top => new("BlueSG", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("BlueSG", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_BreakingGlass);

        public string Definition => "Blue Stained Glass";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
