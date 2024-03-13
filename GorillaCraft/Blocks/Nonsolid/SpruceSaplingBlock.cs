using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Nonsolid
{
    public class SpruceSaplingBlock : IBlock
    {
        public BlockFaceInfo Front => new("SpurceSapling", typeof(Surface_Grass));
        public BlockFaceInfo Left => new("SpurceSapling", typeof(Surface_Grass));
        public BlockFaceInfo Back => new("SpurceSapling", typeof(Surface_Grass));
        public BlockFaceInfo Right => new("SpurceSapling", typeof(Surface_Grass));
        public BlockFaceInfo Top => new("SpurceSapling", typeof(Surface_Grass));
        public BlockFaceInfo Bottom => new("SpurceSapling", typeof(Surface_Grass));

        public Type PlaceSoundType => typeof(Interaction_Grass);
        public Type DestroySoundType => typeof(Interaction_Grass);

        public string BlockDefinition => "Spruce Sapling";
        public BlockForm BlockForm => BlockForm.Decoration;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
