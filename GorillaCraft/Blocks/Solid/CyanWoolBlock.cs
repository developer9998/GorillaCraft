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

        public Type PlaceSound => typeof(Interaction_Cloth);
        public Type BreakSound => typeof(Interaction_Cloth);

        public string Definition => "Cyan Wool";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
