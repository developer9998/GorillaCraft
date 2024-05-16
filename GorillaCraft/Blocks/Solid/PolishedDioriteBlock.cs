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

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Polished Diorite";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
