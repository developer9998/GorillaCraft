using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class PumpkinBlock : IBlock
    {
        public BlockFaceInfo Front => new("PumpkinFront", typeof(Surface_Wood));
        public BlockFaceInfo Left => new("PumpkinSide", typeof(Surface_Wood));
        public BlockFaceInfo Back => new("PumpkinSide", typeof(Surface_Wood));
        public BlockFaceInfo Right => new("PumpkinSide", typeof(Surface_Wood));
        public BlockFaceInfo Up => new("PumpkinTop", typeof(Surface_Wood));
        public BlockFaceInfo Down => new("PumpkinTop", typeof(Surface_Wood));

        public Type PlaceSoundType => typeof(Interaction_Wood);
        public Type DestroySoundType => typeof(Interaction_Wood);

        public string BlockDefinition => "Pumpkin";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.VerticalRotation_90;
    }
}
