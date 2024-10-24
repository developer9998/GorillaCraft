using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class OakPlanksBlock : IBlock
    {
        public BlockFaceInfo Front => new("OakPlanks", typeof(Surface_Wood));
        public BlockFaceInfo Left => new("OakPlanks", typeof(Surface_Wood));
        public BlockFaceInfo Back => new("OakPlanks", typeof(Surface_Wood));
        public BlockFaceInfo Right => new("OakPlanks", typeof(Surface_Wood));
        public BlockFaceInfo Top => new("OakPlanks", typeof(Surface_Wood));
        public BlockFaceInfo Bottom => new("OakPlanks", typeof(Surface_Wood));

        public Type PlaceSound => typeof(Interaction_Wood);
        public Type BreakSound => typeof(Interaction_Wood);

        public string Definition => "Oak Planks";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
