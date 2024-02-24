using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class SandBlock : IBlock
    {
        public BlockFaceInfo Front => new("Sand", typeof(Surface_Sand));
        public BlockFaceInfo Left => new("Sand", typeof(Surface_Sand));
        public BlockFaceInfo Back => new("Sand", typeof(Surface_Sand));
        public BlockFaceInfo Right => new("Sand", typeof(Surface_Sand));
        public BlockFaceInfo Up => new("Sand", typeof(Surface_Sand));
        public BlockFaceInfo Down => new("Sand", typeof(Surface_Sand));

        public Type PlaceSoundType => typeof(Interaction_Sand);
        public Type DestroySoundType => typeof(Interaction_Sand);

        public string BlockDefinition => "Sand";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
