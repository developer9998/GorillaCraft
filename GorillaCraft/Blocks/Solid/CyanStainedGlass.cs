using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class CyanStainedGlass : IBlock
    {
        public BlockFaceInfo Front => new("CyanSG", typeof(Surface_Default));
        public BlockFaceInfo Left => new("CyanSG", typeof(Surface_Default));
        public BlockFaceInfo Back => new("CyanSG", typeof(Surface_Default));
        public BlockFaceInfo Right => new("CyanSG", typeof(Surface_Default));
        public BlockFaceInfo Top => new("CyanSG", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("CyanSG", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_BreakingGlass);

        public string Definition => "Cyan Stained Glass";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
