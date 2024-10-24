using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class RedstoneBlock : IBlock
    {
        public BlockFaceInfo Front => new("RedstoneBlock", typeof(Surface_Default));
        public BlockFaceInfo Left => new("RedstoneBlock", typeof(Surface_Default));
        public BlockFaceInfo Back => new("RedstoneBlock", typeof(Surface_Default));
        public BlockFaceInfo Right => new("RedstoneBlock", typeof(Surface_Default));
        public BlockFaceInfo Top => new("RedstoneBlock", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("RedstoneBlock", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Block of Redstone";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
