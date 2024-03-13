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

        public Type PlaceSoundType => typeof(Interaction_Wood);
        public Type DestroySoundType => typeof(Interaction_Wood);

        public string BlockDefinition => "Ladder";
        public BlockForm BlockForm => BlockForm.Ladder;
        public BlockPlacement BlockPlacement => BlockPlacement.VerticalRotation_90;
    }
}
