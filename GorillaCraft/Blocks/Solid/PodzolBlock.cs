using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class PodzolBlock : IBlock
    {
        public BlockFaceInfo Front => new("PodzolSide", typeof(Surface_Gravel));
        public BlockFaceInfo Left => new("PodzolSide", typeof(Surface_Gravel));
        public BlockFaceInfo Back => new("PodzolSide", typeof(Surface_Gravel));
        public BlockFaceInfo Right => new("PodzolSide", typeof(Surface_Gravel));
        public BlockFaceInfo Top => new("PodzolTop", typeof(Surface_Gravel));
        public BlockFaceInfo Bottom => new("Dirt", typeof(Surface_Gravel));

        public Type PlaceSoundType => typeof(Interaction_Gravel);
        public Type DestroySoundType => typeof(Interaction_Gravel);

        public string BlockDefinition => "Podzol";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
