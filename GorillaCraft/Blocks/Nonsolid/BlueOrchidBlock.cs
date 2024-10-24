using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Nonsolid
{
    public class BlueOrchidBlock : IBlock
    {
        public BlockFaceInfo Front => new("Blue Orchid", typeof(Surface_Grass));
        public BlockFaceInfo Left => new("Blue Orchid", typeof(Surface_Grass));
        public BlockFaceInfo Back => new("Blue Orchid", typeof(Surface_Grass));
        public BlockFaceInfo Right => new("Blue Orchid", typeof(Surface_Grass));
        public BlockFaceInfo Top => new("Blue Orchid", typeof(Surface_Grass));
        public BlockFaceInfo Bottom => new("Blue Orchid", typeof(Surface_Grass));

        public Type PlaceSound => typeof(Interaction_Grass);
        public Type BreakSound => typeof(Interaction_Grass);

        public string Definition => "Blue Orchid";
        public BlockForm Form => BlockForm.Decoration;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
