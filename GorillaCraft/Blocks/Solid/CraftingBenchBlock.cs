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
        public BlockFaceInfo Up => new("CraftTop", typeof(Surface_Wood));
        public BlockFaceInfo Down => new("OakPlanks", typeof(Surface_Wood));

        public Type PlaceSoundType => typeof(Interaction_Wood);
        public Type DestroySoundType => typeof(Interaction_Wood);

        public string BlockDefinition => "Crafting Table";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.VerticalRotation_90;
    }
}
