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
        public BlockFaceInfo Up => new("DarkOakSapling", typeof(Surface_Grass));
        public BlockFaceInfo Down => new("DarkOakSapling", typeof(Surface_Grass));

        public Type PlaceSoundType => typeof(Interaction_Grass);
        public Type DestroySoundType => typeof(Interaction_Grass);

        public string BlockDefinition => "Dark Oak Sapling";
        public BlockForm BlockForm => BlockForm.Nonsolid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
