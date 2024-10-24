using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class MagentaWoolBlock : IBlock
    {
        public BlockFaceInfo Front => new("MagentaWool", typeof(Surface_Cloth));
        public BlockFaceInfo Left => new("MagentaWool", typeof(Surface_Cloth));
        public BlockFaceInfo Back => new("MagentaWool", typeof(Surface_Cloth));
        public BlockFaceInfo Right => new("MagentaWool", typeof(Surface_Cloth));
        public BlockFaceInfo Top => new("MagentaWool", typeof(Surface_Cloth));
        public BlockFaceInfo Bottom => new("MagentaWool", typeof(Surface_Cloth));

        public Type PlaceSound => typeof(Interaction_Cloth);
        public Type BreakSound => typeof(Interaction_Cloth);

        public string Definition => "Magenta Wool";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
