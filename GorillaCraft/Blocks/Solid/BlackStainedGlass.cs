using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class BlackStainedGlass : IBlock
    {
        public BlockFaceInfo Front => new("BlackSG", typeof(Surface_Default));
        public BlockFaceInfo Left => new("BlackSG", typeof(Surface_Default));
        public BlockFaceInfo Back => new("BlackSG", typeof(Surface_Default));
        public BlockFaceInfo Right => new("BlackSG", typeof(Surface_Default));
        public BlockFaceInfo Top => new("BlackSG", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("BlackSG", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_BreakingGlass);

        public string BlockDefinition => "Black Stained Glass";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
