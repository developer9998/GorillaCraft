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

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Brown Terracotta";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
