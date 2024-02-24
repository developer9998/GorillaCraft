using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class YellowWoolBlock : IBlock
    {
        public BlockFaceInfo Front => new("YellowWool", typeof(Surface_Cloth));
        public BlockFaceInfo Left => new("YellowWool", typeof(Surface_Cloth));
        public BlockFaceInfo Back => new("YellowWool", typeof(Surface_Cloth));
        public BlockFaceInfo Right => new("YellowWool", typeof(Surface_Cloth));
        public BlockFaceInfo Up => new("YellowWool", typeof(Surface_Cloth));
        public BlockFaceInfo Down => new("YellowWool", typeof(Surface_Cloth));

        public Type PlaceSoundType => typeof(Interaction_Cloth);
        public Type DestroySoundType => typeof(Interaction_Cloth);

        public string BlockDefinition => "Yellow Wool";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
