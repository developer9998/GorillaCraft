using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks
{
    public class DirtBlock : IBlock
    {
        public BlockFaceInfo Front => new("Dirt", typeof(Surface_Gravel));
        public BlockFaceInfo Left => new("Dirt", typeof(Surface_Gravel));
        public BlockFaceInfo Back => new("Dirt", typeof(Surface_Gravel));
        public BlockFaceInfo Right => new("Dirt", typeof(Surface_Gravel));
        public BlockFaceInfo Up => new("Dirt", typeof(Surface_Gravel));
        public BlockFaceInfo Down => new("Dirt", typeof(Surface_Gravel));

        public Type PlaceSoundType => typeof(Interaction_Gravel);
        public Type DestroySoundType => typeof(Interaction_Gravel);

        public string BlockDefinition => "Dirt";
        public BlockBehaviourType BlockType => BlockBehaviourType.Default;
    }
}
