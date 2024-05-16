using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class PurpleStainedGlass : IBlock
    {
        public BlockFaceInfo Front => new("PurpleSG", typeof(Surface_Default));
        public BlockFaceInfo Left => new("PurpleSG", typeof(Surface_Default));
        public BlockFaceInfo Back => new("PurpleSG", typeof(Surface_Default));
        public BlockFaceInfo Right => new("PurpleSG", typeof(Surface_Default));
        public BlockFaceInfo Top => new("PurpleSG", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("PurpleSG", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_BreakingGlass);

        public string BlockDefinition => "Purple Stained Glass";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
