using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Nonsolid
{
    public class BirchSaplingBlock : IBlock
    {
        public BlockFaceInfo Front => new("BirchSapling", typeof(Surface_Grass));
        public BlockFaceInfo Left => new("BirchSapling", typeof(Surface_Grass));
        public BlockFaceInfo Back => new("BirchSapling", typeof(Surface_Grass));
        public BlockFaceInfo Right => new("BirchSapling", typeof(Surface_Grass));
        public BlockFaceInfo Top => new("BirchSapling", typeof(Surface_Grass));
        public BlockFaceInfo Bottom => new("BirchSapling", typeof(Surface_Grass));

        public Type PlaceSoundType => typeof(Interaction_Grass);
        public Type DestroySoundType => typeof(Interaction_Grass);

        public string BlockDefinition => "Birch Sapling";
        public BlockForm BlockForm => BlockForm.Decoration;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
