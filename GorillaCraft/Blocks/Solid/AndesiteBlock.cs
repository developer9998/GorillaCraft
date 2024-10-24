using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class AndesiteBlock : IBlock
    {
        public BlockFaceInfo Front => new("Andesite", typeof(Surface_Default));
        public BlockFaceInfo Left => new("Andesite", typeof(Surface_Default));
        public BlockFaceInfo Back => new("Andesite", typeof(Surface_Default));
        public BlockFaceInfo Right => new("Andesite", typeof(Surface_Default));
        public BlockFaceInfo Top => new("Andesite", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("Andesite", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Andesite";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
