using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class PolishedDioriteBlock : IBlock
    {
        public BlockFaceInfo Front => new("PolishedDiorite", typeof(Surface_Default));
        public BlockFaceInfo Left => new("PolishedDiorite", typeof(Surface_Default));
        public BlockFaceInfo Back => new("PolishedDiorite", typeof(Surface_Default));
        public BlockFaceInfo Right => new("PolishedDiorite", typeof(Surface_Default));
        public BlockFaceInfo Top => new("PolishedDiorite", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("PolishedDiorite", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Polished Diorite";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
