using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Nonsolid
{
    public class JungleSaplingBlock : IBlock
    {
        public BlockFaceInfo Front => new("JungleSapling", typeof(Surface_Grass));
        public BlockFaceInfo Left => new("JungleSapling", typeof(Surface_Grass));
        public BlockFaceInfo Back => new("JungleSapling", typeof(Surface_Grass));
        public BlockFaceInfo Right => new("JungleSapling", typeof(Surface_Grass));
        public BlockFaceInfo Top => new("JungleSapling", typeof(Surface_Grass));
        public BlockFaceInfo Bottom => new("JungleSapling", typeof(Surface_Grass));

        public Type PlaceSoundType => typeof(Interaction_Grass);
        public Type DestroySoundType => typeof(Interaction_Grass);

        public string BlockDefinition => "Jungle Sapling";
        public BlockForm BlockForm => BlockForm.Decoration;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
