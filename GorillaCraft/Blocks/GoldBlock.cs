using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks
{
    public class GoldBlock : IBlock
    {
        public BlockFaceInfo Front => new("GoldBlock", typeof(Surface_Default));
        public BlockFaceInfo Left => new("GoldBlock", typeof(Surface_Default));
        public BlockFaceInfo Back => new("GoldBlock", typeof(Surface_Default));
        public BlockFaceInfo Right => new("GoldBlock", typeof(Surface_Default));
        public BlockFaceInfo Up => new("GoldBlock", typeof(Surface_Default));
        public BlockFaceInfo Down => new("GoldBlock", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Gold Block";
        public BlockBehaviourType BlockType => BlockBehaviourType.Default;
    }
}
