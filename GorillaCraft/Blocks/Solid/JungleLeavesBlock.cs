using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class JungleLeavesBlock : IBlock
    {
        public BlockFaceInfo Front => new("JungleLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Left => new("JungleLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Back => new("JungleLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Right => new("JungleLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Top => new("JungleLeaves", typeof(Surface_Grass));
        public BlockFaceInfo Bottom => new("JungleLeaves", typeof(Surface_Grass));

        public Type PlaceSound => typeof(Interaction_Grass);
        public Type BreakSound => typeof(Interaction_Grass);

        public string Definition => "Jungle Leaves";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
