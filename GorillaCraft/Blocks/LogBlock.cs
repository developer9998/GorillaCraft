using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks
{
    public class LogBlock : IBlock
    {
        public BlockFaceInfo Front => new("OakLog", typeof(Surface_Wood));
        public BlockFaceInfo Left => new("OakLog", typeof(Surface_Wood));
        public BlockFaceInfo Back => new("OakLog", typeof(Surface_Wood));
        public BlockFaceInfo Right => new("OakLog", typeof(Surface_Wood));
        public BlockFaceInfo Up => new("OakLogTop", typeof(Surface_Wood));
        public BlockFaceInfo Down => new("OakLogTop", typeof(Surface_Wood));

        public Type PlaceSoundType => typeof(Interaction_Wood);
        public Type DestroySoundType => typeof(Interaction_Wood);

        public string BlockDefinition => "Wood";
        public BlockBehaviourType BlockType => BlockBehaviourType.FullRotation;
    }
}
