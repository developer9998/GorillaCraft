using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class LimeWoolBlock : IBlock
    {
        public BlockFaceInfo Front => new("LimeWool", typeof(Surface_Cloth));
        public BlockFaceInfo Left => new("LimeWool", typeof(Surface_Cloth));
        public BlockFaceInfo Back => new("LimeWool", typeof(Surface_Cloth));
        public BlockFaceInfo Right => new("LimeWool", typeof(Surface_Cloth));
        public BlockFaceInfo Top => new("LimeWool", typeof(Surface_Cloth));
        public BlockFaceInfo Bottom => new("LimeWool", typeof(Surface_Cloth));

        public Type PlaceSound => typeof(Interaction_Cloth);
        public Type BreakSound => typeof(Interaction_Cloth);

        public string Definition => "Lime Wool";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
