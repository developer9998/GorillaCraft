using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks
{
    public class WhiteWoolBlock : IBlock
    {
        public BlockFaceInfo Front => new("WhiteWool", typeof(Surface_Cloth));
        public BlockFaceInfo Left => new("WhiteWool", typeof(Surface_Cloth));
        public BlockFaceInfo Back => new("WhiteWool", typeof(Surface_Cloth));
        public BlockFaceInfo Right => new("WhiteWool", typeof(Surface_Cloth));
        public BlockFaceInfo Up => new("WhiteWool", typeof(Surface_Cloth));
        public BlockFaceInfo Down => new("WhiteWool", typeof(Surface_Cloth));

        public Type PlaceSoundType => typeof(Interaction_Cloth);
        public Type DestroySoundType => typeof(Interaction_Cloth);

        public string BlockDefinition => "White Wool";
        public BlockBehaviourType BlockType => BlockBehaviourType.Default;
    }
}
