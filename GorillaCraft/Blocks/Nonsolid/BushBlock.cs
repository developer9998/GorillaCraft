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

        public Type PlaceSoundType => typeof(Interaction_Grass);
        public Type DestroySoundType => typeof(Interaction_Grass);

        public string BlockDefinition => "Dead Bush";
        public BlockForm BlockForm => BlockForm.Decoration;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
