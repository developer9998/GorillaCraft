using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class PinkStainedGlass : IBlock
    {
        public BlockFaceInfo Front => new("PinkSG", typeof(Surface_Default));
        public BlockFaceInfo Left => new("PinkSG", typeof(Surface_Default));
        public BlockFaceInfo Back => new("PinkSG", typeof(Surface_Default));
        public BlockFaceInfo Right => new("PinkSG", typeof(Surface_Default));
        public BlockFaceInfo Top => new("PinkSG", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("PinkSG", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_BreakingGlass);

        public string BlockDefinition => "Pink Stained Glass";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
