using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class SandBlock : IBlock
    {
        public BlockFaceInfo Front => new("Sand", typeof(Surface_Sand));
        public BlockFaceInfo Left => new("Sand", typeof(Surface_Sand));
        public BlockFaceInfo Back => new("Sand", typeof(Surface_Sand));
        public BlockFaceInfo Right => new("Sand", typeof(Surface_Sand));
        public BlockFaceInfo Top => new("Sand", typeof(Surface_Sand));
        public BlockFaceInfo Bottom => new("Sand", typeof(Surface_Sand));

        public Type PlaceSound => typeof(Interaction_Sand);
        public Type BreakSound => typeof(Interaction_Sand);

        public string Definition => "Sand";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
