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
        public BlockFaceInfo Top => new("SpurceLogTop", typeof(Surface_Wood));
        public BlockFaceInfo Bottom => new("SpurceLogTop", typeof(Surface_Wood));

        public Type PlaceSound => typeof(Interaction_Wood);
        public Type BreakSound => typeof(Interaction_Wood);

        public string Definition => "Spruce Log";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.FullRotation;
    }
}
