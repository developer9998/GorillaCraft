using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class SpruceLeavesBlock : IBlock
    {
        public BlockFaceInfo Front => new("SpurceLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Left => new("SpurceLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Back => new("SpurceLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Right => new("SpurceLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Up => new("SpurceLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Down => new("SpurceLeaves", typeof(Surface_Grass));

        public Type PlaceSoundType => typeof(Interaction_Grass);
        public Type DestroySoundType => typeof(Interaction_Grass);

        public string BlockDefinition => "Spruce Leaves";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
