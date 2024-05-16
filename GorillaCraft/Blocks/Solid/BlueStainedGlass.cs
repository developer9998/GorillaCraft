using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class BlueStainedGlass : IBlock
    {
        public BlockFaceInfo Front => new("BlueSG", typeof(Surface_Default));
        public BlockFaceInfo Left => new("BlueSG", typeof(Surface_Default));
        public BlockFaceInfo Back => new("BlueSG", typeof(Surface_Default));
        public BlockFaceInfo Right => new("BlueSG", typeof(Surface_Default));
        public BlockFaceInfo Top => new("BlueSG", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("BlueSG", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_BreakingGlass);

        public string BlockDefinition => "Blue Stained Glass";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
