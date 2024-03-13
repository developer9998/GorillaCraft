using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class RedstoneOreBlock : IBlock
    {
        public BlockFaceInfo Front => new("RedstoneOre", typeof(Surface_Default));
        public BlockFaceInfo Left => new("RedstoneOre", typeof(Surface_Default));
        public BlockFaceInfo Back => new("RedstoneOre", typeof(Surface_Default));
        public BlockFaceInfo Right => new("RedstoneOre", typeof(Surface_Default));
        public BlockFaceInfo Top => new("RedstoneOre", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("RedstoneOre", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Redstone Ore";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
