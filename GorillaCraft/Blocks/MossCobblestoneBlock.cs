using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks
{
    public class MossCobblestoneBlock : IBlock
    {
        public BlockFaceInfo Front => new("MossyCobble", typeof(Surface_Default));
        public BlockFaceInfo Left => new("MossyCobble", typeof(Surface_Default));
        public BlockFaceInfo Back => new("MossyCobble", typeof(Surface_Default));
        public BlockFaceInfo Right => new("MossyCobble", typeof(Surface_Default));
        public BlockFaceInfo Up => new("MossyCobble", typeof(Surface_Default));
        public BlockFaceInfo Down => new("MossyCobble", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Mossy Cobblestone";
        public BlockBehaviourType BlockType => BlockBehaviourType.Default;
    }
}
