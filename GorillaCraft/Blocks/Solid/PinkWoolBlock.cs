using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class PinkWoolBlock : IBlock
    {
        public BlockFaceInfo Front => new("PinkWool", typeof(Surface_Cloth));
        public BlockFaceInfo Left => new("PinkWool", typeof(Surface_Cloth));
        public BlockFaceInfo Back => new("PinkWool", typeof(Surface_Cloth));
        public BlockFaceInfo Right => new("PinkWool", typeof(Surface_Cloth));
        public BlockFaceInfo Top => new("PinkWool", typeof(Surface_Cloth));
        public BlockFaceInfo Bottom => new("PinkWool", typeof(Surface_Cloth));

        public Type PlaceSound => typeof(Interaction_Cloth);
        public Type BreakSound => typeof(Interaction_Cloth);

        public string Definition => "Pink Wool";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
