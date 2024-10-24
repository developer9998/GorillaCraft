using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class JackOLanternBlock : IBlock
    {
        public BlockFaceInfo Front => new("PumpkinFront_On", typeof(Surface_Wood));
        public BlockFaceInfo Left => new("PumpkinSide", typeof(Surface_Wood));
        public BlockFaceInfo Back => new("PumpkinSide", typeof(Surface_Wood));
        public BlockFaceInfo Right => new("PumpkinSide", typeof(Surface_Wood));
        public BlockFaceInfo Top => new("PumpkinTop", typeof(Surface_Wood));
        public BlockFaceInfo Bottom => new("PumpkinTop", typeof(Surface_Wood));

        public Type PlaceSound => typeof(Interaction_Wood);
        public Type BreakSound => typeof(Interaction_Wood);

        public string Definition => "Jack o'Lantern";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.VerticalRotation_90;
    }
}
