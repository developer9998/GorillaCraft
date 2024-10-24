using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class RedTerracotta : IBlock
    {
        public BlockFaceInfo Front => new("RedTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Left => new("RedTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Back => new("RedTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Right => new("RedTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Top => new("RedTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("RedTerracotta", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Red Terracotta";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
