using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class BookshelfBlock : IBlock
    {
        public BlockFaceInfo Front => new("Bookshelf", typeof(Surface_Wood));
        public BlockFaceInfo Left => new("Bookshelf", typeof(Surface_Wood));
        public BlockFaceInfo Back => new("Bookshelf", typeof(Surface_Wood));
        public BlockFaceInfo Right => new("Bookshelf", typeof(Surface_Wood));
        public BlockFaceInfo Top => new("OakPlanks", typeof(Surface_Wood));
        public BlockFaceInfo Bottom => new("OakPlanks", typeof(Surface_Wood));

        public Type PlaceSound => typeof(Interaction_Wood);
        public Type BreakSound => typeof(Interaction_Wood);

        public string Definition => "Bookshelf";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
