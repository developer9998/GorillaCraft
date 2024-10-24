using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class WhiteWoolBlock : IBlock
    {
        public BlockFaceInfo Front => new("WhiteWool", typeof(Surface_Cloth));
        public BlockFaceInfo Left => new("WhiteWool", typeof(Surface_Cloth));
        public BlockFaceInfo Back => new("WhiteWool", typeof(Surface_Cloth));
        public BlockFaceInfo Right => new("WhiteWool", typeof(Surface_Cloth));
        public BlockFaceInfo Top => new("WhiteWool", typeof(Surface_Cloth));
        public BlockFaceInfo Bottom => new("WhiteWool", typeof(Surface_Cloth));

        public Type PlaceSound => typeof(Interaction_Cloth);
        public Type BreakSound => typeof(Interaction_Cloth);

        public string Definition => "White Wool";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
