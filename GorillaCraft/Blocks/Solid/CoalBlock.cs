using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class CoalBlock : IBlock
    {
        public BlockFaceInfo Front => new("CoalBlock", typeof(Surface_Default));
        public BlockFaceInfo Left => new("CoalBlock", typeof(Surface_Default));
        public BlockFaceInfo Back => new("CoalBlock", typeof(Surface_Default));
        public BlockFaceInfo Right => new("CoalBlock", typeof(Surface_Default));
        public BlockFaceInfo Top => new("CoalBlock", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("CoalBlock", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Block of Coal";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
