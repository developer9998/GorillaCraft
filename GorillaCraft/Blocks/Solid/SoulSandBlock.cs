using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class SoulSandBlock : IBlock
    {
        public BlockFaceInfo Front => new("SoulSand", typeof(Surface_Sand));
        public BlockFaceInfo Left => new("SoulSand", typeof(Surface_Sand));
        public BlockFaceInfo Back => new("SoulSand", typeof(Surface_Sand));
        public BlockFaceInfo Right => new("SoulSand", typeof(Surface_Sand));
        public BlockFaceInfo Top => new("SoulSand", typeof(Surface_Sand));
        public BlockFaceInfo Bottom => new("SoulSand", typeof(Surface_Sand));

        public Type PlaceSound => typeof(Interaction_Sand);
        public Type BreakSound => typeof(Interaction_Sand);

        public string Definition => "Soul Sand";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
