using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class IronOreBlock : IBlock
    {
        public BlockFaceInfo Front => new("IronOre", typeof(Surface_Default));
        public BlockFaceInfo Left => new("IronOre", typeof(Surface_Default));
        public BlockFaceInfo Back => new("IronOre", typeof(Surface_Default));
        public BlockFaceInfo Right => new("IronOre", typeof(Surface_Default));
        public BlockFaceInfo Top => new("IronOre", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("IronOre", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Iron Ore";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
