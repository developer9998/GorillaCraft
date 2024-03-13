using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Nonsolid
{
    public class AcaciaSaplingBlock : IBlock
    {
        public BlockFaceInfo Front => new("AcaciaSapling", typeof(Surface_Grass));
        public BlockFaceInfo Left => new("AcaciaSapling", typeof(Surface_Grass));
        public BlockFaceInfo Back => new("AcaciaSapling", typeof(Surface_Grass));
        public BlockFaceInfo Right => new("AcaciaSapling", typeof(Surface_Grass));
        public BlockFaceInfo Top => new("AcaciaSapling", typeof(Surface_Grass));
        public BlockFaceInfo Bottom => new("AcaciaSapling", typeof(Surface_Grass));

        public Type PlaceSoundType => typeof(Interaction_Grass);
        public Type DestroySoundType => typeof(Interaction_Grass);

        public string BlockDefinition => "Acacia Sapling";
        public BlockForm BlockForm => BlockForm.Decoration;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
