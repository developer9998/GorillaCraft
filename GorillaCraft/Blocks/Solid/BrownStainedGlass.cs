using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class BrownStainedGlass : IBlock
    {
        public BlockFaceInfo Front => new("BrownSG", typeof(Surface_Default));
        public BlockFaceInfo Left => new("BrownSG", typeof(Surface_Default));
        public BlockFaceInfo Back => new("BrownSG", typeof(Surface_Default));
        public BlockFaceInfo Right => new("BrownSG", typeof(Surface_Default));
        public BlockFaceInfo Top => new("BrownSG", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("BrownSG", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_BreakingGlass);

        public string BlockDefinition => "Brown Stained Glass";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
