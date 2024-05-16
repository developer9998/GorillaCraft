using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class GraniteBlock : IBlock
    {
        public BlockFaceInfo Front => new("Granite", typeof(Surface_Default));
        public BlockFaceInfo Left => new("Granite", typeof(Surface_Default));
        public BlockFaceInfo Back => new("Granite", typeof(Surface_Default));
        public BlockFaceInfo Right => new("Granite", typeof(Surface_Default));
        public BlockFaceInfo Top => new("Granite", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("Granite", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Granite";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
