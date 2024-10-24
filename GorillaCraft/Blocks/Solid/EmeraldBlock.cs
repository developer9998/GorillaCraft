using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class EmeraldBlock : IBlock
    {
        public BlockFaceInfo Front => new("EmeraldBlock", typeof(Surface_Default));
        public BlockFaceInfo Left => new("EmeraldBlock", typeof(Surface_Default));
        public BlockFaceInfo Back => new("EmeraldBlock", typeof(Surface_Default));
        public BlockFaceInfo Right => new("EmeraldBlock", typeof(Surface_Default));
        public BlockFaceInfo Top => new("EmeraldBlock", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("EmeraldBlock", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Block of Emerald";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
