using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class BlackTerracotta : IBlock
    {
        public BlockFaceInfo Front => new("BlackTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Left => new("BlackTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Back => new("BlackTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Right => new("BlackTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Top => new("BlackTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("BlackTerracotta", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Black Terracotta";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
