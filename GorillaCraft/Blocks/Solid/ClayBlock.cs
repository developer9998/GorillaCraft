using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class ClayBlock : IBlock
    {
        public BlockFaceInfo Front => new("Clay", typeof(Surface_Gravel));
        public BlockFaceInfo Left => new("Clay", typeof(Surface_Gravel));
        public BlockFaceInfo Back => new("Clay", typeof(Surface_Gravel));
        public BlockFaceInfo Right => new("Clay", typeof(Surface_Gravel));
        public BlockFaceInfo Top => new("Clay", typeof(Surface_Gravel));
        public BlockFaceInfo Bottom => new("Clay", typeof(Surface_Gravel));

        public Type PlaceSoundType => typeof(Interaction_Gravel);
        public Type DestroySoundType => typeof(Interaction_Gravel);

        public string BlockDefinition => "Clay";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
