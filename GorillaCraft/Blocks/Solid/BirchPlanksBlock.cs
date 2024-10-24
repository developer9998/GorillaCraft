using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class BirchPlanksBlock : IBlock
    {
        public BlockFaceInfo Front => new("BirchPlanks", typeof(Surface_Wood));
        public BlockFaceInfo Left => new("BirchPlanks", typeof(Surface_Wood));
        public BlockFaceInfo Back => new("BirchPlanks", typeof(Surface_Wood));
        public BlockFaceInfo Right => new("BirchPlanks", typeof(Surface_Wood));
        public BlockFaceInfo Top => new("BirchPlanks", typeof(Surface_Wood));
        public BlockFaceInfo Bottom => new("BirchPlanks", typeof(Surface_Wood));

        public Type PlaceSound => typeof(Interaction_Wood);
        public Type BreakSound => typeof(Interaction_Wood);

        public string Definition => "Birch Planks";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
