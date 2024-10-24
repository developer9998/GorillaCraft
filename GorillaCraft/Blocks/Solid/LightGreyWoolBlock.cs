using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class LightGreyWoolBlock : IBlock
    {
        public BlockFaceInfo Front => new("LightGreyWool", typeof(Surface_Cloth));
        public BlockFaceInfo Left => new("LightGreyWool", typeof(Surface_Cloth));
        public BlockFaceInfo Back => new("LightGreyWool", typeof(Surface_Cloth));
        public BlockFaceInfo Right => new("LightGreyWool", typeof(Surface_Cloth));
        public BlockFaceInfo Top => new("LightGreyWool", typeof(Surface_Cloth));
        public BlockFaceInfo Bottom => new("LightGreyWool", typeof(Surface_Cloth));

        public Type PlaceSound => typeof(Interaction_Cloth);
        public Type BreakSound => typeof(Interaction_Cloth);

        public string Definition => "Light Grey Wool";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
