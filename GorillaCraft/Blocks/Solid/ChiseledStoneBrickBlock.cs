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

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Chiseled Stone Bricks";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
