using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class GreenWoolBlock : IBlock
    {
        public BlockFaceInfo Front => new("GreenWool", typeof(Surface_Cloth));
        public BlockFaceInfo Left => new("GreenWool", typeof(Surface_Cloth));
        public BlockFaceInfo Back => new("GreenWool", typeof(Surface_Cloth));
        public BlockFaceInfo Right => new("GreenWool", typeof(Surface_Cloth));
        public BlockFaceInfo Top => new("GreenWool", typeof(Surface_Cloth));
        public BlockFaceInfo Bottom => new("GreenWool", typeof(Surface_Cloth));

        public Type PlaceSound => typeof(Interaction_Cloth);
        public Type BreakSound => typeof(Interaction_Cloth);

        public string Definition => "Green Wool";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
