using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class Terracotta : IBlock
    {
        public BlockFaceInfo Front => new("Terracotta", typeof(Surface_Default));
        public BlockFaceInfo Left => new("Terracotta", typeof(Surface_Default));
        public BlockFaceInfo Back => new("Terracotta", typeof(Surface_Default));
        public BlockFaceInfo Right => new("Terracotta", typeof(Surface_Default));
        public BlockFaceInfo Top => new("Terracotta", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("Terracotta", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Terracotta";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
