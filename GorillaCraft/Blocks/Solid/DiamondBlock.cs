using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;
using System.Collections.Generic;
using System.Text;

namespace GorillaCraft.Blocks.Solid
{
    public class DiamondBlock : IBlock
    {
        public BlockFaceInfo Front => new("DiamondBlock", typeof(Surface_Default));
        public BlockFaceInfo Left => new("DiamondBlock", typeof(Surface_Default));
        public BlockFaceInfo Back => new("DiamondBlock", typeof(Surface_Default));
        public BlockFaceInfo Right => new("DiamondBlock", typeof(Surface_Default));
        public BlockFaceInfo Up => new("DiamondBlock", typeof(Surface_Default));
        public BlockFaceInfo Down => new("DiamondBlock", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Diamond Block";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
