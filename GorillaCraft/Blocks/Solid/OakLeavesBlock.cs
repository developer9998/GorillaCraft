using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class OakLeavesBlock : IBlock
    {
        public BlockFaceInfo Front => new("OakLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Left => new("OakLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Back => new("OakLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Right => new("OakLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Up => new("OakLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Down => new("OakLeaves", typeof(Surface_Grass));

        public Type PlaceSoundType => typeof(Interaction_Grass);
        public Type DestroySoundType => typeof(Interaction_Grass);

        public string BlockDefinition => "Oak Leaves";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
