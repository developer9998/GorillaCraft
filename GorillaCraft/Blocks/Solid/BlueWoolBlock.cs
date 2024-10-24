using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class BlueWoolBlock : IBlock
    {
        public BlockFaceInfo Front => new("BlueWool", typeof(Surface_Cloth));
        public BlockFaceInfo Left => new("BlueWool", typeof(Surface_Cloth));
        public BlockFaceInfo Back => new("BlueWool", typeof(Surface_Cloth));
        public BlockFaceInfo Right => new("BlueWool", typeof(Surface_Cloth));
        public BlockFaceInfo Top => new("BlueWool", typeof(Surface_Cloth));
        public BlockFaceInfo Bottom => new("BlueWool", typeof(Surface_Cloth));

        public Type PlaceSound => typeof(Interaction_Cloth);
        public Type BreakSound => typeof(Interaction_Cloth);

        public string Definition => "Blue Wool";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
