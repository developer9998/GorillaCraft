using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class ChiseledStoneBrickBlock : IBlock
    {
        public BlockFaceInfo Front => new("ChiseledStoneBrick", typeof(Surface_Default));
        public BlockFaceInfo Left => new("ChiseledStoneBrick", typeof(Surface_Default));
        public BlockFaceInfo Back => new("ChiseledStoneBrick", typeof(Surface_Default));
        public BlockFaceInfo Right => new("ChiseledStoneBrick", typeof(Surface_Default));
        public BlockFaceInfo Top => new("ChiseledStoneBrick", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("ChiseledStoneBrick", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Chiseled Stone Bricks";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
