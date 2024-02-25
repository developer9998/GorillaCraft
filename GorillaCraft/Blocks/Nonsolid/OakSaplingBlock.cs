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
        public BlockFaceInfo Up => new("OakSapling", typeof(Surface_Grass));
        public BlockFaceInfo Down => new("OakSapling", typeof(Surface_Grass));

        public Type PlaceSoundType => typeof(Interaction_Grass);
        public Type DestroySoundType => typeof(Interaction_Grass);

        public string BlockDefinition => "Oak Sapling";
        public BlockForm BlockForm => BlockForm.Nonsolid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
