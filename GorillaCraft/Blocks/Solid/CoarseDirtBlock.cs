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

        public Type PlaceSound => typeof(Interaction_Gravel);
        public Type BreakSound => typeof(Interaction_Gravel);

        public string Definition => "Coarse Dirt";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
