using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class MossStoneBrickBlock : IBlock
    {
        public BlockFaceInfo Front => new("MossyStoneBrick", typeof(Surface_Default));
        public BlockFaceInfo Left => new("MossyStoneBrick", typeof(Surface_Default));
        public BlockFaceInfo Back => new("MossyStoneBrick", typeof(Surface_Default));
        public BlockFaceInfo Right => new("MossyStoneBrick", typeof(Surface_Default));
        public BlockFaceInfo Top => new("MossyStoneBrick", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("MossyStoneBrick", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Mossy Stone Bricks";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
