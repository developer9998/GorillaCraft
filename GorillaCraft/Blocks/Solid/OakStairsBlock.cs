using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class OakStairsBlock : IBlock
    {
        public BlockFaceInfo Front => new("OakPlanks", typeof(Surface_Wood));
        public BlockFaceInfo Left => new("OakPlanks", typeof(Surface_Wood));
        public BlockFaceInfo Back => new("OakPlanks", typeof(Surface_Wood));
        public BlockFaceInfo Right => new("OakPlanks", typeof(Surface_Wood));
        public BlockFaceInfo Top => new("OakPlanks", typeof(Surface_Wood));
        public BlockFaceInfo Bottom => new("OakPlanks", typeof(Surface_Wood));

        public Type PlaceSoundType => typeof(Interaction_Wood);
        public Type DestroySoundType => typeof(Interaction_Wood);

        public string BlockDefinition => "Oak Stairs";
        public BlockForm BlockForm => BlockForm.StairsTest;
        public BlockPlacement BlockPlacement => BlockPlacement.VerticalRotation_90;
    }
}
