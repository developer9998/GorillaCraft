using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class PackedIceBlock : IBlock
    {
        public BlockFaceInfo Front => new("PackedIce", typeof(Surface_Default));
        public BlockFaceInfo Left => new("PackedIce", typeof(Surface_Default));
        public BlockFaceInfo Back => new("PackedIce", typeof(Surface_Default));
        public BlockFaceInfo Right => new("PackedIce", typeof(Surface_Default));
        public BlockFaceInfo Top => new("PackedIce", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("PackedIce", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_BreakingGlass);

        public string Definition => "Packed Ice";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
