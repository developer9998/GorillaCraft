using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Nonsolid
{
    public class LadderBlock : IBlock
    {
        public BlockFaceInfo Front => new("Ladder", typeof(Surface_Ladder));
        public BlockFaceInfo Left => new("Ladder", typeof(Surface_Ladder));
        public BlockFaceInfo Back => new("Ladder", typeof(Surface_Ladder));
        public BlockFaceInfo Right => new("Ladder", typeof(Surface_Ladder));
        public BlockFaceInfo Top => new("Ladder", typeof(Surface_Ladder));
        public BlockFaceInfo Bottom => new("Ladder", typeof(Surface_Ladder));

        public Type PlaceSound => typeof(Interaction_Wood);
        public Type BreakSound => typeof(Interaction_Wood);

        public string Definition => "Ladder";
        public BlockForm Form => BlockForm.Ladder;
        public BlockPlacement Placement => BlockPlacement.VerticalRotation_90;
    }
}
