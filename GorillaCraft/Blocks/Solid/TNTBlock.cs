using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class TNTBlock : IBlock
    {
        public BlockFaceInfo Front => new("TNTFront", typeof(Surface_Grass));
        public BlockFaceInfo Left => new("TNTFront", typeof(Surface_Grass));
        public BlockFaceInfo Back => new("TNTFront", typeof(Surface_Grass));
        public BlockFaceInfo Right => new("TNTFront", typeof(Surface_Grass));
        public BlockFaceInfo Top => new("TNTTop", typeof(Surface_Grass));
        public BlockFaceInfo Bottom => new("TNTBottom", typeof(Surface_Grass));

        public Type PlaceSound => typeof(Interaction_Grass);
        public Type BreakSound => typeof(Interaction_Grass);

        public string Definition => "TNT";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
