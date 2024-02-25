using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class EmeraldOreBlock : IBlock
    {
        public BlockFaceInfo Front => new("EmeraldOre", typeof(Surface_Default));
        public BlockFaceInfo Left => new("EmeraldOre", typeof(Surface_Default));
        public BlockFaceInfo Back => new("EmeraldOre", typeof(Surface_Default));
        public BlockFaceInfo Right => new("EmeraldOre", typeof(Surface_Default));
        public BlockFaceInfo Up => new("EmeraldOre", typeof(Surface_Default));
        public BlockFaceInfo Down => new("EmeraldOre", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Emerald Ore";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
