using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class IronBlock : IBlock
    {
        public BlockFaceInfo Front => new("IronBlock", typeof(Surface_Default));
        public BlockFaceInfo Left => new("IronBlock", typeof(Surface_Default));
        public BlockFaceInfo Back => new("IronBlock", typeof(Surface_Default));
        public BlockFaceInfo Right => new("IronBlock", typeof(Surface_Default));
        public BlockFaceInfo Top => new("IronBlock", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("IronBlock", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Block of Iron";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
