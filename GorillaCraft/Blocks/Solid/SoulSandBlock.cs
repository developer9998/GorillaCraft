using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class SoulSandBlock : IBlock
    {
        public BlockFaceInfo Front => new("SoulSand", typeof(Surface_Sand));
        public BlockFaceInfo Left => new("SoulSand", typeof(Surface_Sand));
        public BlockFaceInfo Back => new("SoulSand", typeof(Surface_Sand));
        public BlockFaceInfo Right => new("SoulSand", typeof(Surface_Sand));
        public BlockFaceInfo Top => new("SoulSand", typeof(Surface_Sand));
        public BlockFaceInfo Bottom => new("SoulSand", typeof(Surface_Sand));

        public Type PlaceSoundType => typeof(Interaction_Sand);
        public Type DestroySoundType => typeof(Interaction_Sand);

        public string BlockDefinition => "Soul Sand";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
