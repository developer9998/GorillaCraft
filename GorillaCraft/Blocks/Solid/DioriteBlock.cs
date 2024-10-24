using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class DioriteBlock : IBlock
    {
        public BlockFaceInfo Front => new("Diorite", typeof(Surface_Default));
        public BlockFaceInfo Left => new("Diorite", typeof(Surface_Default));
        public BlockFaceInfo Back => new("Diorite", typeof(Surface_Default));
        public BlockFaceInfo Right => new("Diorite", typeof(Surface_Default));
        public BlockFaceInfo Top => new("Diorite", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("Diorite", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Diorite";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
