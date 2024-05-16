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

        public Type PlaceSoundType => typeof(Interaction_Grass);
        public Type DestroySoundType => typeof(Interaction_Grass);

        public string BlockDefinition => "Blue Orchid";
        public BlockForm BlockForm => BlockForm.Decoration;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
