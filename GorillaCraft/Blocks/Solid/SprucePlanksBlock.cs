using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class SprucePlanksBlock : IBlock
    {
        public BlockFaceInfo Front => new("SpurcePlanks", typeof(Surface_Wood));
        public BlockFaceInfo Left => new("SpurcePlanks", typeof(Surface_Wood));
        public BlockFaceInfo Back => new("SpurcePlanks", typeof(Surface_Wood));
        public BlockFaceInfo Right => new("SpurcePlanks", typeof(Surface_Wood));
        public BlockFaceInfo Up => new("SpurcePlanks", typeof(Surface_Wood));
        public BlockFaceInfo Down => new("SpurcePlanks", typeof(Surface_Wood));

        public Type PlaceSoundType => typeof(Interaction_Wood);
        public Type DestroySoundType => typeof(Interaction_Wood);

        public string BlockDefinition => "Spruce Planks";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
