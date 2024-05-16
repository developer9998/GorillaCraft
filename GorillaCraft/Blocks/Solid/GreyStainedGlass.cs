using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class GreyStainedGlass : IBlock
    {
        public BlockFaceInfo Front => new("GraySG", typeof(Surface_Default));
        public BlockFaceInfo Left => new("GraySG", typeof(Surface_Default));
        public BlockFaceInfo Back => new("GraySG", typeof(Surface_Default));
        public BlockFaceInfo Right => new("GraySG", typeof(Surface_Default));
        public BlockFaceInfo Top => new("GraySG", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("GraySG", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_BreakingGlass);

        public string BlockDefinition => "Grey Stained Glass";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
