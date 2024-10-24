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

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Black Terracotta";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
