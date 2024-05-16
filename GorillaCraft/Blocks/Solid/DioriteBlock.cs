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

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Diorite";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
