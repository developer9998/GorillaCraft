using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class ChiseledSandstoneBlock : IBlock
    {
        public BlockFaceInfo Front => new("SandstoneDesign", typeof(Surface_Default));
        public BlockFaceInfo Left => new("SandstoneDesign", typeof(Surface_Default));
        public BlockFaceInfo Back => new("SandstoneDesign", typeof(Surface_Default));
        public BlockFaceInfo Right => new("SandstoneDesign", typeof(Surface_Default));
        public BlockFaceInfo Top => new("SandstoneTop", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("SandstoneBottom", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Chiseled Sandstone";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
