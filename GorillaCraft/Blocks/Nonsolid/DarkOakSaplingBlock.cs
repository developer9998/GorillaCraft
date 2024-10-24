using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Nonsolid
{
    public class DarkOakSaplingBlock : IBlock
    {
        public BlockFaceInfo Front => new("DarkOakSapling", typeof(Surface_Grass));
        public BlockFaceInfo Left => new("DarkOakSapling", typeof(Surface_Grass));
        public BlockFaceInfo Back => new("DarkOakSapling", typeof(Surface_Grass));
        public BlockFaceInfo Right => new("DarkOakSapling", typeof(Surface_Grass));
        public BlockFaceInfo Top => new("DarkOakSapling", typeof(Surface_Grass));
        public BlockFaceInfo Bottom => new("DarkOakSapling", typeof(Surface_Grass));

        public Type PlaceSound => typeof(Interaction_Grass);
        public Type BreakSound => typeof(Interaction_Grass);

        public string Definition => "Dark Oak Sapling";
        public BlockForm Form => BlockForm.Decoration;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
