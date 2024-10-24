using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class BrownWoolBlock : IBlock
    {
        public BlockFaceInfo Front => new("BrownWool", typeof(Surface_Cloth));
        public BlockFaceInfo Left => new("BrownWool", typeof(Surface_Cloth));
        public BlockFaceInfo Back => new("BrownWool", typeof(Surface_Cloth));
        public BlockFaceInfo Right => new("BrownWool", typeof(Surface_Cloth));
        public BlockFaceInfo Top => new("BrownWool", typeof(Surface_Cloth));
        public BlockFaceInfo Bottom => new("BrownWool", typeof(Surface_Cloth));

        public Type PlaceSound => typeof(Interaction_Cloth);
        public Type BreakSound => typeof(Interaction_Cloth);

        public string Definition => "Brown Wool";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
