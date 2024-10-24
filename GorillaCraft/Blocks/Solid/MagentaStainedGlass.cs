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

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_BreakingGlass);

        public string Definition => "Magneta Stained Glass";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
