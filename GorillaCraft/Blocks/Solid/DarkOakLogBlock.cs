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
        public BlockFaceInfo Top => new("DarkOakLogTop", typeof(Surface_Wood));
        public BlockFaceInfo Bottom => new("DarkOakLogTop", typeof(Surface_Wood));

        public Type PlaceSound => typeof(Interaction_Wood);
        public Type BreakSound => typeof(Interaction_Wood);

        public string Definition => "Dark Oak Log";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.FullRotation;
    }
}
