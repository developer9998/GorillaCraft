using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class BrownTerracotta : IBlock
    {
        public BlockFaceInfo Front => new("BrownTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Left => new("BrownTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Back => new("BrownTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Right => new("BrownTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Top => new("BrownTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("BrownTerracotta", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Brown Terracotta";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
