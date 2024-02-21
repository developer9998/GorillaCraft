using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks
{
    public class MagentaWoolBlock : IBlock
    {
        public BlockFaceInfo Front => new("MagentaWool", typeof(Surface_Cloth));
        public BlockFaceInfo Left => new("MagentaWool", typeof(Surface_Cloth));
        public BlockFaceInfo Back => new("MagentaWool", typeof(Surface_Cloth));
        public BlockFaceInfo Right => new("MagentaWool", typeof(Surface_Cloth));
        public BlockFaceInfo Up => new("MagentaWool", typeof(Surface_Cloth));
        public BlockFaceInfo Down => new("MagentaWool", typeof(Surface_Cloth));

        public Type PlaceSoundType => typeof(Interaction_Cloth);
        public Type DestroySoundType => typeof(Interaction_Cloth);

        public string BlockDefinition => "Magenta Wool";
        public BlockBehaviourType BlockType => BlockBehaviourType.Default;
    }
}
