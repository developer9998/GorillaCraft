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

        public Type PlaceSoundType => typeof(Interaction_Wood);
        public Type DestroySoundType => typeof(Interaction_Wood);

        public string BlockDefinition => "Bookshelf";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
