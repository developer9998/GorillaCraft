using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class BlackWoolBlock : IBlock
    {
        public BlockFaceInfo Front => new("BlackWool", typeof(Surface_Cloth));
        public BlockFaceInfo Left => new("BlackWool", typeof(Surface_Cloth));
        public BlockFaceInfo Back => new("BlackWool", typeof(Surface_Cloth));
        public BlockFaceInfo Right => new("BlackWool", typeof(Surface_Cloth));
        public BlockFaceInfo Up => new("BlackWool", typeof(Surface_Cloth));
        public BlockFaceInfo Down => new("BlackWool", typeof(Surface_Cloth));

        public Type PlaceSoundType => typeof(Interaction_Cloth);
        public Type DestroySoundType => typeof(Interaction_Cloth);

        public string BlockDefinition => "Black Wool";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
