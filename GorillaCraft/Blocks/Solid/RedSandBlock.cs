using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class RedSandBlock : IBlock
    {
        public BlockFaceInfo Front => new("Sand 1", typeof(Surface_Sand));
        public BlockFaceInfo Left => new("Sand 1", typeof(Surface_Sand));
        public BlockFaceInfo Back => new("Sand 1", typeof(Surface_Sand));
        public BlockFaceInfo Right => new("Sand 1", typeof(Surface_Sand));
        public BlockFaceInfo Top => new("Sand 1", typeof(Surface_Sand));
        public BlockFaceInfo Bottom => new("Sand 1", typeof(Surface_Sand));

        public Type PlaceSound => typeof(Interaction_Sand);
        public Type BreakSound => typeof(Interaction_Sand);

        public string Definition => "Red Sand";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
