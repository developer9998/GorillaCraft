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
        public BlockFaceInfo Up => new("LapisOre", typeof(Surface_Default));
        public BlockFaceInfo Down => new("LapisOre", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Lapis Ore";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
