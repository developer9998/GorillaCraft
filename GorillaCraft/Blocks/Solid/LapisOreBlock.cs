using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class LapisOreBlock : IBlock
    {
        public BlockFaceInfo Front => new("LapisOre", typeof(Surface_Default));
        public BlockFaceInfo Left => new("LapisOre", typeof(Surface_Default));
        public BlockFaceInfo Back => new("LapisOre", typeof(Surface_Default));
        public BlockFaceInfo Right => new("LapisOre", typeof(Surface_Default));
        public BlockFaceInfo Top => new("LapisOre", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("LapisOre", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Lapis Lazuli Ore";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
