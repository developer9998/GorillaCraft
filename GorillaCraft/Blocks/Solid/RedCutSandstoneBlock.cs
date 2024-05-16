using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class RedCutSandstoneBlock : IBlock
    {
        public BlockFaceInfo Front => new("SandstoneCut 1", typeof(Surface_Default));
        public BlockFaceInfo Left => new("SandstoneCut 1", typeof(Surface_Default));
        public BlockFaceInfo Back => new("SandstoneCut 1", typeof(Surface_Default));
        public BlockFaceInfo Right => new("SandstoneCut 1", typeof(Surface_Default));
        public BlockFaceInfo Top => new("SandstoneTop 1", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("SandstoneBottom 1", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Cut Red Sandstone";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
