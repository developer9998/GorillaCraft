using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class BirchLeavesBlock : IBlock
    {
        public BlockFaceInfo Front => new("BirchLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Left => new("BirchLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Back => new("BirchLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Right => new("BirchLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Top => new("BirchLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Bottom => new("BirchLeaves", typeof(Surface_Grass));

        public Type PlaceSoundType => typeof(Interaction_Grass);
        public Type DestroySoundType => typeof(Interaction_Grass);

        public string BlockDefinition => "Birch Leaves";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
