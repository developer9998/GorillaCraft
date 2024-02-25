using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class GlowstoneBlock : IBlock
    {
        public BlockFaceInfo Front => new("Glowstone", typeof(Surface_Default));
        public BlockFaceInfo Left => new("Glowstone", typeof(Surface_Default));
        public BlockFaceInfo Back => new("Glowstone", typeof(Surface_Default));
        public BlockFaceInfo Right => new("Glowstone", typeof(Surface_Default));
        public BlockFaceInfo Up => new("Glowstone", typeof(Surface_Default));
        public BlockFaceInfo Down => new("Glowstone", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_BreakingGlass);

        public string BlockDefinition => "Glowstone";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
