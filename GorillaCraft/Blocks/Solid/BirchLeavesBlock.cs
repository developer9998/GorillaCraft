using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class BirchLeavesBlock : IBlock
    {
        public BlockFaceInfo Front => new("BirchLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Left => new("BirchLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Back => new("BirchLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Right => new("BirchLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Top => new("BirchLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Bottom => new("BirchLeaves", typeof(Surface_Grass));

        public Type PlaceSound => typeof(Interaction_Grass);
        public Type BreakSound => typeof(Interaction_Grass);

        public string Definition => "Birch Leaves";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
