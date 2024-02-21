using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks
{
    public class LeavesBlock : IBlock
    {
        public BlockFaceInfo Front => new("OakLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Left => new("OakLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Back => new("OakLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Right => new("OakLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Up => new("OakLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Down => new("OakLeaves", typeof(Surface_Grass));

        public Type PlaceSoundType => typeof(Interaction_Grass);
        public Type DestroySoundType => typeof(Interaction_Grass);

        public string BlockDefinition => "Leaves";
        public BlockBehaviourType BlockType => BlockBehaviourType.Default;
    }
}
