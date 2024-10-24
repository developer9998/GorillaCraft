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
        public BlockFaceInfo Top => new("LapisBlock", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("LapisBlock", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Block of Lapis Lazuli";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
