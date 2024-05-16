using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class GreenTerracotta : IBlock
    {
        public BlockFaceInfo Front => new("GreenTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Left => new("GreenTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Back => new("GreenTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Right => new("GreenTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Top => new("GreenTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("GreenTerracotta", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Green Terracotta";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
