using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class PurpleStainedGlass : IBlock
    {
        public BlockFaceInfo Front => new("PurpleSG", typeof(Surface_Default));
        public BlockFaceInfo Left => new("PurpleSG", typeof(Surface_Default));
        public BlockFaceInfo Back => new("PurpleSG", typeof(Surface_Default));
        public BlockFaceInfo Right => new("PurpleSG", typeof(Surface_Default));
        public BlockFaceInfo Top => new("PurpleSG", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("PurpleSG", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_BreakingGlass);

        public string Definition => "Purple Stained Glass";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
