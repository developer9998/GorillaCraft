using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class DiamondBlock : IBlock
    {
        public BlockFaceInfo Front => new("DiamondBlock", typeof(Surface_Default));
        public BlockFaceInfo Left => new("DiamondBlock", typeof(Surface_Default));
        public BlockFaceInfo Back => new("DiamondBlock", typeof(Surface_Default));
        public BlockFaceInfo Right => new("DiamondBlock", typeof(Surface_Default));
        public BlockFaceInfo Top => new("DiamondBlock", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("DiamondBlock", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Block of Diamond";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
