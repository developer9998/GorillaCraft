using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class RedCutSandstoneBlock : IBlock
    {
        public BlockFaceInfo Front => new("SandstoneCut 1", typeof(Surface_Default));
        public BlockFaceInfo Left => new("SandstoneCut 1", typeof(Surface_Default));
        public BlockFaceInfo Back => new("SandstoneCut 1", typeof(Surface_Default));
        public BlockFaceInfo Right => new("SandstoneCut 1", typeof(Surface_Default));
        public BlockFaceInfo Top => new("SandstoneTop 1", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("SandstoneBottom 1", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Cut Red Sandstone";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
