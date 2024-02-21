using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks
{
    public class GreyWoolBlock : IBlock
    {
        public BlockFaceInfo Front => new("GreyWool", typeof(Surface_Cloth));
        public BlockFaceInfo Left => new("GreyWool", typeof(Surface_Cloth));
        public BlockFaceInfo Back => new("GreyWool", typeof(Surface_Cloth));
        public BlockFaceInfo Right => new("GreyWool", typeof(Surface_Cloth));
        public BlockFaceInfo Up => new("GreyWool", typeof(Surface_Cloth));
        public BlockFaceInfo Down => new("GreyWool", typeof(Surface_Cloth));

        public Type PlaceSoundType => typeof(Interaction_Cloth);
        public Type DestroySoundType => typeof(Interaction_Cloth);

        public string BlockDefinition => "Grey Wool";
        public BlockBehaviourType BlockType => BlockBehaviourType.Default;
    }
}
