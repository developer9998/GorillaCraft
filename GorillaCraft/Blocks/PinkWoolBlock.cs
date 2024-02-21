using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks
{
    public class PinkWoolBlock : IBlock
    {
        public BlockFaceInfo Front => new("PinkWool", typeof(Surface_Cloth));
        public BlockFaceInfo Left => new("PinkWool", typeof(Surface_Cloth));
        public BlockFaceInfo Back => new("PinkWool", typeof(Surface_Cloth));
        public BlockFaceInfo Right => new("PinkWool", typeof(Surface_Cloth));
        public BlockFaceInfo Up => new("PinkWool", typeof(Surface_Cloth));
        public BlockFaceInfo Down => new("PinkWool", typeof(Surface_Cloth));

        public Type PlaceSoundType => typeof(Interaction_Cloth);
        public Type DestroySoundType => typeof(Interaction_Cloth);

        public string BlockDefinition => "Pink Wool";
        public BlockBehaviourType BlockType => BlockBehaviourType.Default;
    }
}
