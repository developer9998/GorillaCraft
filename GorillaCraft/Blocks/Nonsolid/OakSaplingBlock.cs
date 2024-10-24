using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Nonsolid
{
    public class OakSaplingBlock : IBlock
    {
        public BlockFaceInfo Front => new("OakSapling", typeof(Surface_Grass));
        public BlockFaceInfo Left => new("OakSapling", typeof(Surface_Grass));
        public BlockFaceInfo Back => new("OakSapling", typeof(Surface_Grass));
        public BlockFaceInfo Right => new("OakSapling", typeof(Surface_Grass));
        public BlockFaceInfo Top => new("OakSapling", typeof(Surface_Grass));
        public BlockFaceInfo Bottom => new("OakSapling", typeof(Surface_Grass));

        public Type PlaceSound => typeof(Interaction_Grass);
        public Type BreakSound => typeof(Interaction_Grass);

        public string Definition => "Oak Sapling";
        public BlockForm Form => BlockForm.Decoration;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
