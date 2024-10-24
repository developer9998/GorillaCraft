using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class CyanTerracotta : IBlock
    {
        public BlockFaceInfo Front => new("CyanTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Left => new("CyanTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Back => new("CyanTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Right => new("CyanTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Top => new("CyanTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("CyanTerracotta", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Cyan Terracotta";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
