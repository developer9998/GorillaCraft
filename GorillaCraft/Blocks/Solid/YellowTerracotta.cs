using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class YellowTerracotta : IBlock
    {
        public BlockFaceInfo Front => new("YellowTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Left => new("YellowTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Back => new("YellowTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Right => new("YellowTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Top => new("YellowTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("YellowTerracotta", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Yellow Terracotta";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
