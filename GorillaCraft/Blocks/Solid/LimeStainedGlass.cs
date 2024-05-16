using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class LimeStainedGlass : IBlock
    {
        public BlockFaceInfo Front => new("LimeSG", typeof(Surface_Default));
        public BlockFaceInfo Left => new("LimeSG", typeof(Surface_Default));
        public BlockFaceInfo Back => new("LimeSG", typeof(Surface_Default));
        public BlockFaceInfo Right => new("LimeSG", typeof(Surface_Default));
        public BlockFaceInfo Top => new("LimeSG", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("LimeSG", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_BreakingGlass);

        public string BlockDefinition => "Lime Stained Glass";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
