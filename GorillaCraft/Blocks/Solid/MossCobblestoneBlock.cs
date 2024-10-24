using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class MossCobblestoneBlock : IBlock
    {
        public BlockFaceInfo Front => new("MossyCobble", typeof(Surface_Default));
        public BlockFaceInfo Left => new("MossyCobble", typeof(Surface_Default));
        public BlockFaceInfo Back => new("MossyCobble", typeof(Surface_Default));
        public BlockFaceInfo Right => new("MossyCobble", typeof(Surface_Default));
        public BlockFaceInfo Top => new("MossyCobble", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("MossyCobble", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Mossy Cobblestone";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
