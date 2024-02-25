using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class LapisBlock : IBlock
    {
        public BlockFaceInfo Front => new("LapisBlock", typeof(Surface_Default));
        public BlockFaceInfo Left => new("LapisBlock", typeof(Surface_Default));
        public BlockFaceInfo Back => new("LapisBlock", typeof(Surface_Default));
        public BlockFaceInfo Right => new("LapisBlock", typeof(Surface_Default));
        public BlockFaceInfo Up => new("LapisBlock", typeof(Surface_Default));
        public BlockFaceInfo Down => new("LapisBlock", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Lapis Block";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
