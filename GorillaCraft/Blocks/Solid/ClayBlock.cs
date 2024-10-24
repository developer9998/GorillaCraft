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

        public Type PlaceSound => typeof(Interaction_Gravel);
        public Type BreakSound => typeof(Interaction_Gravel);

        public string Definition => "Clay";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
