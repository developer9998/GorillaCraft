using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class WhiteTerracotta : IBlock
    {
        public BlockFaceInfo Front => new("WhiteTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Left => new("WhiteTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Back => new("WhiteTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Right => new("WhiteTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Top => new("WhiteTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("WhiteTerracotta", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "White Terracotta";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
