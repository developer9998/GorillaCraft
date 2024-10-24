using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Nonsolid
{
    public class BushBlock : IBlock
    {
        public BlockFaceInfo Front => new("Bush", typeof(Surface_Grass));
        public BlockFaceInfo Left => new("Bush", typeof(Surface_Grass));
        public BlockFaceInfo Back => new("Bush", typeof(Surface_Grass));
        public BlockFaceInfo Right => new("Bush", typeof(Surface_Grass));
        public BlockFaceInfo Top => new("Bush", typeof(Surface_Grass));
        public BlockFaceInfo Bottom => new("Bush", typeof(Surface_Grass));

        public Type PlaceSound => typeof(Interaction_Grass);
        public Type BreakSound => typeof(Interaction_Grass);

        public string Definition => "Dead Bush";
        public BlockForm Form => BlockForm.Decoration;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
