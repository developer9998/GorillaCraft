using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks
{
    public class LightGreyWoolBlock : IBlock
    {
        public BlockFaceInfo Front => new("LightGreyWool", typeof(Surface_Cloth));
        public BlockFaceInfo Left => new("LightGreyWool", typeof(Surface_Cloth));
        public BlockFaceInfo Back => new("LightGreyWool", typeof(Surface_Cloth));
        public BlockFaceInfo Right => new("LightGreyWool", typeof(Surface_Cloth));
        public BlockFaceInfo Up => new("LightGreyWool", typeof(Surface_Cloth));
        public BlockFaceInfo Down => new("LightGreyWool", typeof(Surface_Cloth));

        public Type PlaceSoundType => typeof(Interaction_Cloth);
        public Type DestroySoundType => typeof(Interaction_Cloth);

        public string BlockDefinition => "Light Grey Wool";
        public BlockBehaviourType BlockType => BlockBehaviourType.Default;
    }
}
