using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks
{
    public class GlassBlock : IBlock
    {
        public BlockFaceInfo Front => new("Glass", typeof(Surface_Default));
        public BlockFaceInfo Left => new("Glass", typeof(Surface_Default));
        public BlockFaceInfo Back => new("Glass", typeof(Surface_Default));
        public BlockFaceInfo Right => new("Glass", typeof(Surface_Default));
        public BlockFaceInfo Up => new("Glass", typeof(Surface_Default));
        public BlockFaceInfo Down => new("Glass", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_BreakingGlass);

        public string BlockDefinition => "Glass";
        public BlockBehaviourType BlockType => BlockBehaviourType.Default;
    }
}
