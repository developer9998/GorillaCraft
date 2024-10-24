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
        public BlockFaceInfo Top => new("OrangeWool", typeof(Surface_Cloth));
        public BlockFaceInfo Bottom => new("OrangeWool", typeof(Surface_Cloth));

        public Type PlaceSound => typeof(Interaction_Cloth);
        public Type BreakSound => typeof(Interaction_Cloth);

        public string Definition => "Orange Wool";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
