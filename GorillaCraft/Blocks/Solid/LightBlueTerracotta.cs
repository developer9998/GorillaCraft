using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class LightBlueTerracotta : IBlock
    {
        public BlockFaceInfo Front => new("LBTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Left => new("LBTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Back => new("LBTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Right => new("LBTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Top => new("LBTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("LBTerracotta", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Light Blue Terracotta";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
