using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class SprucePlanksBlock : IBlock
    {
        public BlockFaceInfo Front => new("SpurcePlanks", typeof(Surface_Wood));
        public BlockFaceInfo Left => new("SpurcePlanks", typeof(Surface_Wood));
        public BlockFaceInfo Back => new("SpurcePlanks", typeof(Surface_Wood));
        public BlockFaceInfo Right => new("SpurcePlanks", typeof(Surface_Wood));
        public BlockFaceInfo Top => new("SpurcePlanks", typeof(Surface_Wood));
        public BlockFaceInfo Bottom => new("SpurcePlanks", typeof(Surface_Wood));

        public Type PlaceSound => typeof(Interaction_Wood);
        public Type BreakSound => typeof(Interaction_Wood);

        public string Definition => "Spruce Planks";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
