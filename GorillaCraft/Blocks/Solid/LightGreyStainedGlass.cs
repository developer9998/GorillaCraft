using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class LightGreyStainedGlass : IBlock
    {
        public BlockFaceInfo Front => new("LGSG", typeof(Surface_Default));
        public BlockFaceInfo Left => new("LGSG", typeof(Surface_Default));
        public BlockFaceInfo Back => new("LGSG", typeof(Surface_Default));
        public BlockFaceInfo Right => new("LGSG", typeof(Surface_Default));
        public BlockFaceInfo Top => new("LGSG", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("LGSG", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_BreakingGlass);

        public string Definition => "Light Grey Stained Glass";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
