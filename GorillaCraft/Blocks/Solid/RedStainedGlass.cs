using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class RedStainedGlass : IBlock
    {
        public BlockFaceInfo Front => new("RedSG", typeof(Surface_Default));
        public BlockFaceInfo Left => new("RedSG", typeof(Surface_Default));
        public BlockFaceInfo Back => new("RedSG", typeof(Surface_Default));
        public BlockFaceInfo Right => new("RedSG", typeof(Surface_Default));
        public BlockFaceInfo Top => new("RedSG", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("RedSG", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_BreakingGlass);

        public string BlockDefinition => "Red Stained Glass";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
