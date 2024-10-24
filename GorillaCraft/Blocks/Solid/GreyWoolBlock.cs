using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class GreyWoolBlock : IBlock
    {
        public BlockFaceInfo Front => new("GreyWool", typeof(Surface_Cloth));
        public BlockFaceInfo Left => new("GreyWool", typeof(Surface_Cloth));
        public BlockFaceInfo Back => new("GreyWool", typeof(Surface_Cloth));
        public BlockFaceInfo Right => new("GreyWool", typeof(Surface_Cloth));
        public BlockFaceInfo Top => new("GreyWool", typeof(Surface_Cloth));
        public BlockFaceInfo Bottom => new("GreyWool", typeof(Surface_Cloth));

        public Type PlaceSound => typeof(Interaction_Cloth);
        public Type BreakSound => typeof(Interaction_Cloth);

        public string Definition => "Grey Wool";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
