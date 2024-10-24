using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class StoneBlock : IBlock
    {
        public BlockFaceInfo Front => new("Stone", typeof(Surface_Default));
        public BlockFaceInfo Left => new("Stone", typeof(Surface_Default));
        public BlockFaceInfo Back => new("Stone", typeof(Surface_Default));
        public BlockFaceInfo Right => new("Stone", typeof(Surface_Default));
        public BlockFaceInfo Top => new("Stone", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("Stone", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Stone";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
