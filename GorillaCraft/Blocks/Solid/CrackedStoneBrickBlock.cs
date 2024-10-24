using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class CrackedStoneBrickBlock : IBlock
    {
        public BlockFaceInfo Front => new("CrackedStoneBrick", typeof(Surface_Default));
        public BlockFaceInfo Left => new("CrackedStoneBrick", typeof(Surface_Default));
        public BlockFaceInfo Back => new("CrackedStoneBrick", typeof(Surface_Default));
        public BlockFaceInfo Right => new("CrackedStoneBrick", typeof(Surface_Default));
        public BlockFaceInfo Top => new("CrackedStoneBrick", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("CrackedStoneBrick", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Cracked Stone Bricks";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
