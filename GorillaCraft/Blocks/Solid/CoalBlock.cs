using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class CoalBlock : IBlock
    {
        public BlockFaceInfo Front => new("CoalBlock", typeof(Surface_Default));
        public BlockFaceInfo Left => new("CoalBlock", typeof(Surface_Default));
        public BlockFaceInfo Back => new("CoalBlock", typeof(Surface_Default));
        public BlockFaceInfo Right => new("CoalBlock", typeof(Surface_Default));
        public BlockFaceInfo Up => new("CoalBlock", typeof(Surface_Default));
        public BlockFaceInfo Down => new("CoalBlock", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Block of Coal";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
