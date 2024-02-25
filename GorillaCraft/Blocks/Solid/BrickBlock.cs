using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class BrickBlock : IBlock
    {
        public BlockFaceInfo Front => new("Brick", typeof(Surface_Default));
        public BlockFaceInfo Left => new("Brick", typeof(Surface_Default));
        public BlockFaceInfo Back => new("Brick", typeof(Surface_Default));
        public BlockFaceInfo Right => new("Brick", typeof(Surface_Default));
        public BlockFaceInfo Up => new("Brick", typeof(Surface_Default));
        public BlockFaceInfo Down => new("Brick", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Bricks";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
