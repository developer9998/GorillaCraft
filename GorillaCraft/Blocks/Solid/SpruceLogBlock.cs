using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class SpruceLogBlock : IBlock
    {
        public BlockFaceInfo Front => new("SpruceLog", typeof(Surface_Wood));
        public BlockFaceInfo Left => new("SpruceLog", typeof(Surface_Wood));
        public BlockFaceInfo Back => new("SpruceLog", typeof(Surface_Wood));
        public BlockFaceInfo Right => new("SpruceLog", typeof(Surface_Wood));
        public BlockFaceInfo Up => new("SpurceLogTop", typeof(Surface_Wood));
        public BlockFaceInfo Down => new("SpurceLogTop", typeof(Surface_Wood));

        public Type PlaceSoundType => typeof(Interaction_Wood);
        public Type DestroySoundType => typeof(Interaction_Wood);

        public string BlockDefinition => "Spruce Log";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.FullRotation;
    }
}
