using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class MossCobblestoneBlock : IBlock
    {
        public BlockFaceInfo Front => new("MossyCobble", typeof(Surface_Default));
        public BlockFaceInfo Left => new("MossyCobble", typeof(Surface_Default));
        public BlockFaceInfo Back => new("MossyCobble", typeof(Surface_Default));
        public BlockFaceInfo Right => new("MossyCobble", typeof(Surface_Default));
        public BlockFaceInfo Top => new("MossyCobble", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("MossyCobble", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Mossy Cobblestone";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
