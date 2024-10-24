using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class GoldBlock : IBlock
    {
        public BlockFaceInfo Front => new("GoldBlock", typeof(Surface_Default));
        public BlockFaceInfo Left => new("GoldBlock", typeof(Surface_Default));
        public BlockFaceInfo Back => new("GoldBlock", typeof(Surface_Default));
        public BlockFaceInfo Right => new("GoldBlock", typeof(Surface_Default));
        public BlockFaceInfo Top => new("GoldBlock", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("GoldBlock", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Block of Gold";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
