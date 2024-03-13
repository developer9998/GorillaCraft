using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class EmeraldBlock : IBlock
    {
        public BlockFaceInfo Front => new("EmeraldBlock", typeof(Surface_Default));
        public BlockFaceInfo Left => new("EmeraldBlock", typeof(Surface_Default));
        public BlockFaceInfo Back => new("EmeraldBlock", typeof(Surface_Default));
        public BlockFaceInfo Right => new("EmeraldBlock", typeof(Surface_Default));
        public BlockFaceInfo Top => new("EmeraldBlock", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("EmeraldBlock", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Block of Emerald";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
