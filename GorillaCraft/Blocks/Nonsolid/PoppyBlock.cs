using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Nonsolid
{
    public class PoppyBlock : IBlock
    {
        public BlockFaceInfo Front => new("Poppy", typeof(Surface_Grass));
        public BlockFaceInfo Left => new("Poppy", typeof(Surface_Grass));
        public BlockFaceInfo Back => new("Poppy", typeof(Surface_Grass));
        public BlockFaceInfo Right => new("Poppy", typeof(Surface_Grass));
        public BlockFaceInfo Top => new("Poppy", typeof(Surface_Grass));
        public BlockFaceInfo Bottom => new("Poppy", typeof(Surface_Grass));

        public Type PlaceSound => typeof(Interaction_Grass);
        public Type BreakSound => typeof(Interaction_Grass);

        public string Definition => "Poppy";
        public BlockForm Form => BlockForm.Decoration;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
