using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class CraftingBenchBlock : IBlock
    {
        public BlockFaceInfo Front => new("CraftFront", typeof(Surface_Wood));
        public BlockFaceInfo Left => new("CraftSide", typeof(Surface_Wood));
        public BlockFaceInfo Back => new("CraftFront", typeof(Surface_Wood));
        public BlockFaceInfo Right => new("CraftSide", typeof(Surface_Wood));
        public BlockFaceInfo Top => new("CraftTop", typeof(Surface_Wood));
        public BlockFaceInfo Bottom => new("OakPlanks", typeof(Surface_Wood));

        public Type PlaceSound => typeof(Interaction_Wood);
        public Type BreakSound => typeof(Interaction_Wood);

        public string Definition => "Crafting Table";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.VerticalRotation_90;
    }
}
