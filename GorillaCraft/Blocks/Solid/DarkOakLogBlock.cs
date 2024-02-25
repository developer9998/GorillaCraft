using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class DarkOakLogBlock : IBlock
    {
        public BlockFaceInfo Front => new("DarkOakLog", typeof(Surface_Wood));
        public BlockFaceInfo Left => new("DarkOakLog", typeof(Surface_Wood));
        public BlockFaceInfo Back => new("DarkOakLog", typeof(Surface_Wood));
        public BlockFaceInfo Right => new("DarkOakLog", typeof(Surface_Wood));
        public BlockFaceInfo Up => new("DarkOakLogTop", typeof(Surface_Wood));
        public BlockFaceInfo Down => new("DarkOakLogTop", typeof(Surface_Wood));

        public Type PlaceSoundType => typeof(Interaction_Wood);
        public Type DestroySoundType => typeof(Interaction_Wood);

        public string BlockDefinition => "Dark Oak Log";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.FullRotation;
    }
}
