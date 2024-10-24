using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    internal class LightBlueWoolBlock : IBlock
    {
        public BlockFaceInfo Front => new("LightBlueWool", typeof(Surface_Cloth));
        public BlockFaceInfo Left => new("LightBlueWool", typeof(Surface_Cloth));
        public BlockFaceInfo Back => new("LightBlueWool", typeof(Surface_Cloth));
        public BlockFaceInfo Right => new("LightBlueWool", typeof(Surface_Cloth));
        public BlockFaceInfo Top => new("LightBlueWool", typeof(Surface_Cloth));
        public BlockFaceInfo Bottom => new("LightBlueWool", typeof(Surface_Cloth));

        public Type PlaceSound => typeof(Interaction_Cloth);
        public Type BreakSound => typeof(Interaction_Cloth);

        public string Definition => "Light Blue Wool";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
