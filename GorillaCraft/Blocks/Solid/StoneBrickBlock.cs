using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class StoneBrickBlock : IBlock
    {
        public BlockFaceInfo Front => new("StoneBricks", typeof(Surface_Default));
        public BlockFaceInfo Left => new("StoneBricks", typeof(Surface_Default));
        public BlockFaceInfo Back => new("StoneBricks", typeof(Surface_Default));
        public BlockFaceInfo Right => new("StoneBricks", typeof(Surface_Default));
        public BlockFaceInfo Top => new("StoneBricks", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("StoneBricks", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Stone Bricks";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
