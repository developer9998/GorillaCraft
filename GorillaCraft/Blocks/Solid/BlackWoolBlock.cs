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
        public BlockFaceInfo Top => new("BlackWool", typeof(Surface_Cloth));
        public BlockFaceInfo Bottom => new("BlackWool", typeof(Surface_Cloth));

        public Type PlaceSound => typeof(Interaction_Cloth);
        public Type BreakSound => typeof(Interaction_Cloth);

        public string Definition => "Black Wool";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
