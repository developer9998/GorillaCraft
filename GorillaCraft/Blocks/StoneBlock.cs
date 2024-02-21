using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks
{
    public class StoneBlock : IBlock
    {
        public BlockFaceInfo Front => new("Stone", typeof(Surface_Default));
        public BlockFaceInfo Left => new("Stone", typeof(Surface_Default));
        public BlockFaceInfo Back => new("Stone", typeof(Surface_Default));
        public BlockFaceInfo Right => new("Stone", typeof(Surface_Default));
        public BlockFaceInfo Up => new("Stone", typeof(Surface_Default));
        public BlockFaceInfo Down => new("Stone", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Stone";
        public BlockBehaviourType BlockType => BlockBehaviourType.Default;
    }
}
