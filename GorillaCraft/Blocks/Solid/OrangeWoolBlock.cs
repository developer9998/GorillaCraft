using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class OrangeWoolBlock : IBlock
    {
        public BlockFaceInfo Front => new("OrangeWool", typeof(Surface_Cloth));
        public BlockFaceInfo Left => new("OrangeWool", typeof(Surface_Cloth));
        public BlockFaceInfo Back => new("OrangeWool", typeof(Surface_Cloth));
        public BlockFaceInfo Right => new("OrangeWool", typeof(Surface_Cloth));
        public BlockFaceInfo Up => new("OrangeWool", typeof(Surface_Cloth));
        public BlockFaceInfo Down => new("OrangeWool", typeof(Surface_Cloth));

        public Type PlaceSoundType => typeof(Interaction_Cloth);
        public Type DestroySoundType => typeof(Interaction_Cloth);

        public string BlockDefinition => "Orange Wool";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
