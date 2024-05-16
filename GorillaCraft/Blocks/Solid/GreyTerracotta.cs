using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class GreyTerracotta : IBlock
    {
        public BlockFaceInfo Front => new("GreyTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Left => new("GreyTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Back => new("GreyTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Right => new("GreyTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Top => new("GreyTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("GreyTerracotta", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Grey Terracotta";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
