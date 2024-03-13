using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class DiamondBlock : IBlock
    {
        public BlockFaceInfo Front => new("DiamondBlock", typeof(Surface_Default));
        public BlockFaceInfo Left => new("DiamondBlock", typeof(Surface_Default));
        public BlockFaceInfo Back => new("DiamondBlock", typeof(Surface_Default));
        public BlockFaceInfo Right => new("DiamondBlock", typeof(Surface_Default));
        public BlockFaceInfo Top => new("DiamondBlock", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("DiamondBlock", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Block of Diamond";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
