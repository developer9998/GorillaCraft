using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks
{
    public class GrassBlock : IBlock
    {
        public BlockFaceInfo Front => new("GrassSide", typeof(Surface_Gravel));
        public BlockFaceInfo Left => new("GrassSide", typeof(Surface_Gravel));
        public BlockFaceInfo Back => new("GrassSide", typeof(Surface_Gravel));
        public BlockFaceInfo Right => new("GrassSide", typeof(Surface_Gravel));
        public BlockFaceInfo Up => new("GrassTop", typeof(Surface_Grass));
        public BlockFaceInfo Down => new("Dirt", typeof(Surface_Gravel));

        public Type PlaceSoundType => typeof(Interaction_Grass);
        public Type DestroySoundType => typeof(Interaction_Grass);

        public string BlockDefinition => "Grass Block";
        public BlockBehaviourType BlockType => BlockBehaviourType.Default;
    }
}
