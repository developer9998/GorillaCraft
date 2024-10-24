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

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_BreakingGlass);

        public string Definition => "Lime Stained Glass";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
