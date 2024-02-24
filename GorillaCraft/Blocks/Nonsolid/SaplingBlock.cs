using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Nonsolid
{
    public class SaplingBlock : IBlock
    {
        public BlockFaceInfo Front => new("Sapling", typeof(Surface_Grass));
        public BlockFaceInfo Left => new("Sapling", typeof(Surface_Grass));
        public BlockFaceInfo Back => new("Sapling", typeof(Surface_Grass));
        public BlockFaceInfo Right => new("Sapling", typeof(Surface_Grass));
        public BlockFaceInfo Up => new("Sapling", typeof(Surface_Grass));
        public BlockFaceInfo Down => new("Sapling", typeof(Surface_Grass));

        public Type PlaceSoundType => typeof(Interaction_Grass);
        public Type DestroySoundType => typeof(Interaction_Grass);

        public string BlockDefinition => "Sapling";
        public BlockForm BlockForm => BlockForm.Nonsolid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
