using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks
{
    public class BlueWoolBlock : IBlock
    {
        public BlockFaceInfo Front => new("BlueWool", typeof(Surface_Cloth));
        public BlockFaceInfo Left => new("BlueWool", typeof(Surface_Cloth));
        public BlockFaceInfo Back => new("BlueWool", typeof(Surface_Cloth));
        public BlockFaceInfo Right => new("BlueWool", typeof(Surface_Cloth));
        public BlockFaceInfo Up => new("BlueWool", typeof(Surface_Cloth));
        public BlockFaceInfo Down => new("BlueWool", typeof(Surface_Cloth));

        public Type PlaceSoundType => typeof(Interaction_Cloth);
        public Type DestroySoundType => typeof(Interaction_Cloth);

        public string BlockDefinition => "Blue Wool";
        public BlockBehaviourType BlockType => BlockBehaviourType.Default;
    }
}
