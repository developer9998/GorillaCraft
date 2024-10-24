using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class GoldOreBlock : IBlock
    {
        public BlockFaceInfo Front => new("GoldOre", typeof(Surface_Default));
        public BlockFaceInfo Left => new("GoldOre", typeof(Surface_Default));
        public BlockFaceInfo Back => new("GoldOre", typeof(Surface_Default));
        public BlockFaceInfo Right => new("GoldOre", typeof(Surface_Default));
        public BlockFaceInfo Top => new("GoldOre", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("GoldOre", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Gold Ore";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
