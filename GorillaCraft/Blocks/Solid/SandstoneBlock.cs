using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class SandstoneBlock : IBlock
    {
        public BlockFaceInfo Front => new("SandstoneFront", typeof(Surface_Default));
        public BlockFaceInfo Left => new("SandstoneFront", typeof(Surface_Default));
        public BlockFaceInfo Back => new("SandstoneFront", typeof(Surface_Default));
        public BlockFaceInfo Right => new("SandstoneFront", typeof(Surface_Default));
        public BlockFaceInfo Top => new("SandstoneTop", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("SandstoneBottom", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Sandstone";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
