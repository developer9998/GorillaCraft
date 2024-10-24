using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class DirtBlock : IBlock
    {
        public BlockFaceInfo Front => new("Dirt", typeof(Surface_Gravel));
        public BlockFaceInfo Left => new("Dirt", typeof(Surface_Gravel));
        public BlockFaceInfo Back => new("Dirt", typeof(Surface_Gravel));
        public BlockFaceInfo Right => new("Dirt", typeof(Surface_Gravel));
        public BlockFaceInfo Top => new("Dirt", typeof(Surface_Gravel));
        public BlockFaceInfo Bottom => new("Dirt", typeof(Surface_Gravel));

        public Type PlaceSound => typeof(Interaction_Gravel);
        public Type BreakSound => typeof(Interaction_Gravel);

        public string Definition => "Dirt";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
