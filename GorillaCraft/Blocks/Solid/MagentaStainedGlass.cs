using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class MagentaStainedGlass : IBlock
    {
        public BlockFaceInfo Front => new("MagentaSG", typeof(Surface_Default));
        public BlockFaceInfo Left => new("MagentaSG", typeof(Surface_Default));
        public BlockFaceInfo Back => new("MagentaSG", typeof(Surface_Default));
        public BlockFaceInfo Right => new("MagentaSG", typeof(Surface_Default));
        public BlockFaceInfo Top => new("MagentaSG", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("MagentaSG", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_BreakingGlass);

        public string BlockDefinition => "Magneta Stained Glass";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
