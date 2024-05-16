using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class LimeTerracotta : IBlock
    {
        public BlockFaceInfo Front => new("LimeTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Left => new("LimeTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Back => new("LimeTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Right => new("LimeTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Top => new("LimeTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("LimeTerracotta", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Lime Terracotta";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
