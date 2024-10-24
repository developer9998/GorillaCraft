using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class DarkPrismarineBlock : IBlock
    {
        public BlockFaceInfo Front => new("DarkPrismarine", typeof(Surface_Default));
        public BlockFaceInfo Left => new("DarkPrismarine", typeof(Surface_Default));
        public BlockFaceInfo Back => new("DarkPrismarine", typeof(Surface_Default));
        public BlockFaceInfo Right => new("DarkPrismarine", typeof(Surface_Default));
        public BlockFaceInfo Top => new("DarkPrismarine", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("DarkPrismarine", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Dark Prismarine";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
