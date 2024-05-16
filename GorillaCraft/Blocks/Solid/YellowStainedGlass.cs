using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class YellowStainedGlass : IBlock
    {
        public BlockFaceInfo Front => new("YellowSG", typeof(Surface_Default));
        public BlockFaceInfo Left => new("YellowSG", typeof(Surface_Default));
        public BlockFaceInfo Back => new("YellowSG", typeof(Surface_Default));
        public BlockFaceInfo Right => new("YellowSG", typeof(Surface_Default));
        public BlockFaceInfo Top => new("YellowSG", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("YellowSG", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_BreakingGlass);

        public string BlockDefinition => "Yellow Stained Glass";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
