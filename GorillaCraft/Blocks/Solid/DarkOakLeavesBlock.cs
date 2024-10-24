using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class DarkOakLeavesBlock : IBlock
    {
        public BlockFaceInfo Front => new("DarkOakLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Left => new("DarkOakLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Back => new("DarkOakLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Right => new("DarkOakLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Top => new("DarkOakLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Bottom => new("DarkOakLeaves", typeof(Surface_Grass));

        public Type PlaceSound => typeof(Interaction_Grass);
        public Type BreakSound => typeof(Interaction_Grass);

        public string Definition => "Dark Oak Leaves";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
