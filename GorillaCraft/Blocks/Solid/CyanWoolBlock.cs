using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class CyanWoolBlock : IBlock
    {
        public BlockFaceInfo Front => new("CyanWool", typeof(Surface_Cloth));
        public BlockFaceInfo Left => new("CyanWool", typeof(Surface_Cloth));
        public BlockFaceInfo Back => new("CyanWool", typeof(Surface_Cloth));
        public BlockFaceInfo Right => new("CyanWool", typeof(Surface_Cloth));
        public BlockFaceInfo Top => new("CyanWool", typeof(Surface_Cloth));
        public BlockFaceInfo Bottom => new("CyanWool", typeof(Surface_Cloth));

        public Type PlaceSoundType => typeof(Interaction_Cloth);
        public Type DestroySoundType => typeof(Interaction_Cloth);

        public string BlockDefinition => "Cyan Wool";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
