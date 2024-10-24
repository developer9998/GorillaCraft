using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class GrassBlock : IBlock
    {
        public BlockFaceInfo Front => new("GrassSide", typeof(Surface_Gravel));
        public BlockFaceInfo Left => new("GrassSide", typeof(Surface_Gravel));
        public BlockFaceInfo Back => new("GrassSide", typeof(Surface_Gravel));
        public BlockFaceInfo Right => new("GrassSide", typeof(Surface_Gravel));
        public BlockFaceInfo Top => new("GrassTop", typeof(Surface_Grass));
        public BlockFaceInfo Bottom => new("Dirt", typeof(Surface_Gravel));

        public Type PlaceSound => typeof(Interaction_Grass);
        public Type BreakSound => typeof(Interaction_Grass);

        public string Definition => "Grass Block";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
