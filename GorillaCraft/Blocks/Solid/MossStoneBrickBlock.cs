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

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Mossy Stone Bricks";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
