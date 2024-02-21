using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks
{
    public class GreenWoolBlock : IBlock
    {
        public BlockFaceInfo Front => new("GreenWool", typeof(Surface_Cloth));
        public BlockFaceInfo Left => new("GreenWool", typeof(Surface_Cloth));
        public BlockFaceInfo Back => new("GreenWool", typeof(Surface_Cloth));
        public BlockFaceInfo Right => new("GreenWool", typeof(Surface_Cloth));
        public BlockFaceInfo Up => new("GreenWool", typeof(Surface_Cloth));
        public BlockFaceInfo Down => new("GreenWool", typeof(Surface_Cloth));

        public Type PlaceSoundType => typeof(Interaction_Cloth);
        public Type DestroySoundType => typeof(Interaction_Cloth);

        public string BlockDefinition => "Green Wool";
        public BlockBehaviourType BlockType => BlockBehaviourType.Default;
    }
}
