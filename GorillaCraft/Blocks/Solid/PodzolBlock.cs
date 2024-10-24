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

        public Type PlaceSound => typeof(Interaction_Gravel);
        public Type BreakSound => typeof(Interaction_Gravel);

        public string Definition => "Podzol";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
