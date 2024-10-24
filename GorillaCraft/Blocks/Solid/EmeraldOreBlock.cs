using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class EmeraldOreBlock : IBlock
    {
        public BlockFaceInfo Front => new("EmeraldOre", typeof(Surface_Default));
        public BlockFaceInfo Left => new("EmeraldOre", typeof(Surface_Default));
        public BlockFaceInfo Back => new("EmeraldOre", typeof(Surface_Default));
        public BlockFaceInfo Right => new("EmeraldOre", typeof(Surface_Default));
        public BlockFaceInfo Top => new("EmeraldOre", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("EmeraldOre", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Emerald Ore";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
