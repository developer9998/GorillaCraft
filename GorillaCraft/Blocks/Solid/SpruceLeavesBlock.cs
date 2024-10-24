using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class SpruceLeavesBlock : IBlock
    {
        public BlockFaceInfo Front => new("SpurceLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Left => new("SpurceLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Back => new("SpurceLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Right => new("SpurceLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Top => new("SpurceLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Bottom => new("SpurceLeaves", typeof(Surface_Grass));

        public Type PlaceSound => typeof(Interaction_Grass);
        public Type BreakSound => typeof(Interaction_Grass);

        public string Definition => "Spruce Leaves";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
