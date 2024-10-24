using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class PurpleWoolBlock : IBlock
    {
        public BlockFaceInfo Front => new("PurpleWool", typeof(Surface_Cloth));
        public BlockFaceInfo Left => new("PurpleWool", typeof(Surface_Cloth));
        public BlockFaceInfo Back => new("PurpleWool", typeof(Surface_Cloth));
        public BlockFaceInfo Right => new("PurpleWool", typeof(Surface_Cloth));
        public BlockFaceInfo Top => new("PurpleWool", typeof(Surface_Cloth));
        public BlockFaceInfo Bottom => new("PurpleWool", typeof(Surface_Cloth));

        public Type PlaceSound => typeof(Interaction_Cloth);
        public Type BreakSound => typeof(Interaction_Cloth);

        public string Definition => "Purple Wool";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
