using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks
{
    public class BrownWoolBlock : IBlock
    {
        public BlockFaceInfo Front => new("BrownWool", typeof(Surface_Cloth));
        public BlockFaceInfo Left => new("BrownWool", typeof(Surface_Cloth));
        public BlockFaceInfo Back => new("BrownWool", typeof(Surface_Cloth));
        public BlockFaceInfo Right => new("BrownWool", typeof(Surface_Cloth));
        public BlockFaceInfo Up => new("BrownWool", typeof(Surface_Cloth));
        public BlockFaceInfo Down => new("BrownWool", typeof(Surface_Cloth));

        public Type PlaceSoundType => typeof(Interaction_Cloth);
        public Type DestroySoundType => typeof(Interaction_Cloth);

        public string BlockDefinition => "Brown Wool";
        public BlockBehaviourType BlockType => BlockBehaviourType.Default;
    }
}
