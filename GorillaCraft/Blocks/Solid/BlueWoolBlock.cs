using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class BlueWoolBlock : IBlock
    {
        public BlockFaceInfo Front => new("BlueWool", typeof(Surface_Cloth));
        public BlockFaceInfo Left => new("BlueWool", typeof(Surface_Cloth));
        public BlockFaceInfo Back => new("BlueWool", typeof(Surface_Cloth));
        public BlockFaceInfo Right => new("BlueWool", typeof(Surface_Cloth));
        public BlockFaceInfo Top => new("BlueWool", typeof(Surface_Cloth));
        public BlockFaceInfo Bottom => new("BlueWool", typeof(Surface_Cloth));

        public Type PlaceSoundType => typeof(Interaction_Cloth);
        public Type DestroySoundType => typeof(Interaction_Cloth);

        public string BlockDefinition => "Blue Wool";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
