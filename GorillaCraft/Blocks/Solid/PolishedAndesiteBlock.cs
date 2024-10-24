using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class PolishedAndesiteBlock : IBlock
    {
        public BlockFaceInfo Front => new("Polished Andesite", typeof(Surface_Default));
        public BlockFaceInfo Left => new("Polished Andesite", typeof(Surface_Default));
        public BlockFaceInfo Back => new("Polished Andesite", typeof(Surface_Default));
        public BlockFaceInfo Right => new("Polished Andesite", typeof(Surface_Default));
        public BlockFaceInfo Top => new("Polished Andesite", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("Polished Andesite", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Polished Andesite";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
