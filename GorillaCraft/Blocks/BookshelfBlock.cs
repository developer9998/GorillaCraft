using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks
{
    public class BookshelfBlock : IBlock
    {
        public BlockFaceInfo Front => new("Bookshelf", typeof(Surface_Wood));
        public BlockFaceInfo Left => new("Bookshelf", typeof(Surface_Wood));
        public BlockFaceInfo Back => new("Bookshelf", typeof(Surface_Wood));
        public BlockFaceInfo Right => new("Bookshelf", typeof(Surface_Wood));
        public BlockFaceInfo Up => new("OakPlanks", typeof(Surface_Wood));
        public BlockFaceInfo Down => new("OakPlanks", typeof(Surface_Wood));

        public Type PlaceSoundType => typeof(Interaction_Wood);
        public Type DestroySoundType => typeof(Interaction_Wood);

        public string BlockDefinition => "Bookshelf";
        public BlockBehaviourType BlockType => BlockBehaviourType.Default;
    }
}
