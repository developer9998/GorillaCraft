using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class DarkOakPlanksBlock : IBlock
    {
        public BlockFaceInfo Front => new("DarkOakPlanks", typeof(Surface_Wood));
        public BlockFaceInfo Left => new("DarkOakPlanks", typeof(Surface_Wood));
        public BlockFaceInfo Back => new("DarkOakPlanks", typeof(Surface_Wood));
        public BlockFaceInfo Right => new("DarkOakPlanks", typeof(Surface_Wood));
        public BlockFaceInfo Top => new("DarkOakPlanks", typeof(Surface_Wood));
        public BlockFaceInfo Bottom => new("DarkOakPlanks", typeof(Surface_Wood));

        public Type PlaceSound => typeof(Interaction_Wood);
        public Type BreakSound => typeof(Interaction_Wood);

        public string Definition => "Dark Oak Planks";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
