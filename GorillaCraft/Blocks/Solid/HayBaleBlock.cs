using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class HayBaleBlock : IBlock
    {
        public BlockFaceInfo Front => new("HayBaleSide", typeof(Surface_Grass));
        public BlockFaceInfo Left => new("HayBaleSide", typeof(Surface_Grass));
        public BlockFaceInfo Back => new("HayBaleSide", typeof(Surface_Grass));
        public BlockFaceInfo Right => new("HayBaleSide", typeof(Surface_Grass));
        public BlockFaceInfo Top => new("HayBaleTop", typeof(Surface_Grass));
        public BlockFaceInfo Bottom => new("HayBaleTop", typeof(Surface_Grass));

        public Type PlaceSoundType => typeof(Interaction_Grass);
        public Type DestroySoundType => typeof(Interaction_Grass);

        public string BlockDefinition => "Hay Bale";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.FullRotation;
    }
}
