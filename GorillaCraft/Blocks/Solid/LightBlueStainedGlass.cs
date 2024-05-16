using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class LightBlueStainedGlass : IBlock
    {
        public BlockFaceInfo Front => new("LBSG", typeof(Surface_Default));
        public BlockFaceInfo Left => new("LBSG", typeof(Surface_Default));
        public BlockFaceInfo Back => new("LBSG", typeof(Surface_Default));
        public BlockFaceInfo Right => new("LBSG", typeof(Surface_Default));
        public BlockFaceInfo Top => new("LBSG", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("LBSG", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_BreakingGlass);

        public string BlockDefinition => "Light Blue Stained Glass";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
