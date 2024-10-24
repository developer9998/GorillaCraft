using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class AcaciaLeavesBlock : IBlock
    {
        public BlockFaceInfo Front => new("AcaciaLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Left => new("AcaciaLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Back => new("AcaciaLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Right => new("AcaciaLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Top => new("AcaciaLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Bottom => new("AcaciaLeaves", typeof(Surface_Grass));

        public Type PlaceSound => typeof(Interaction_Grass);
        public Type BreakSound => typeof(Interaction_Grass);

        public string Definition => "Acacia Leaves";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
