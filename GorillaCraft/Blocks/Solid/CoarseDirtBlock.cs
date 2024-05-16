using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class CoarseDirtBlock : IBlock
    {
        public BlockFaceInfo Front => new("CoarseDirt", typeof(Surface_Gravel));
        public BlockFaceInfo Left => new("CoarseDirt", typeof(Surface_Gravel));
        public BlockFaceInfo Back => new("CoarseDirt", typeof(Surface_Gravel));
        public BlockFaceInfo Right => new("CoarseDirt", typeof(Surface_Gravel));
        public BlockFaceInfo Top => new("CoarseDirt", typeof(Surface_Gravel));
        public BlockFaceInfo Bottom => new("CoarseDirt", typeof(Surface_Gravel));

        public Type PlaceSoundType => typeof(Interaction_Gravel);
        public Type DestroySoundType => typeof(Interaction_Gravel);

        public string BlockDefinition => "Coarse Dirt";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
