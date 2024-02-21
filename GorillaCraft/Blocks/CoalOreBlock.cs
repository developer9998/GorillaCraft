using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks
{
    public class CoalOreBlock : IBlock
    {
        public BlockFaceInfo Front => new("CoalOre", typeof(Surface_Default));
        public BlockFaceInfo Left => new("CoalOre", typeof(Surface_Default));
        public BlockFaceInfo Back => new("CoalOre", typeof(Surface_Default));
        public BlockFaceInfo Right => new("CoalOre", typeof(Surface_Default));
        public BlockFaceInfo Up => new("CoalOre", typeof(Surface_Default));
        public BlockFaceInfo Down => new("CoalOre", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Coal Ore";
        public BlockBehaviourType BlockType => BlockBehaviourType.Default;
    }
}
