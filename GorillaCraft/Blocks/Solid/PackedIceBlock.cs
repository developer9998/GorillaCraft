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

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_BreakingGlass);

        public string BlockDefinition => "Packed Ice";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
