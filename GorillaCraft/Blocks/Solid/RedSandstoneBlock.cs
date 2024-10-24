using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class RedSandstoneBlock : IBlock
    {
        public BlockFaceInfo Front => new("SandstoneFront 1", typeof(Surface_Default));
        public BlockFaceInfo Left => new("SandstoneFront 1", typeof(Surface_Default));
        public BlockFaceInfo Back => new("SandstoneFront 1", typeof(Surface_Default));
        public BlockFaceInfo Right => new("SandstoneFront 1", typeof(Surface_Default));
        public BlockFaceInfo Top => new("SandstoneTop 1", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("SandstoneBottom 1", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Red Sandstone";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
