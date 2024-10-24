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
        public BlockFaceInfo Top => new("YellowWool", typeof(Surface_Cloth));
        public BlockFaceInfo Bottom => new("YellowWool", typeof(Surface_Cloth));

        public Type PlaceSound => typeof(Interaction_Cloth);
        public Type BreakSound => typeof(Interaction_Cloth);

        public string Definition => "Yellow Wool";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
