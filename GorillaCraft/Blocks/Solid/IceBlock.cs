using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class IceBlock : IBlock
    {
        public BlockFaceInfo Front => new("Ice", typeof(Surface_Default));
        public BlockFaceInfo Left => new("Ice", typeof(Surface_Default));
        public BlockFaceInfo Back => new("Ice", typeof(Surface_Default));
        public BlockFaceInfo Right => new("Ice", typeof(Surface_Default));
        public BlockFaceInfo Top => new("Ice", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("Ice", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_BreakingGlass);

        public string Definition => "Ice";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
