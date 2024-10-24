using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class CobblestoneBlock : IBlock
    {
        public BlockFaceInfo Front => new("Cobblestone", typeof(Surface_Default));
        public BlockFaceInfo Left => new("Cobblestone", typeof(Surface_Default));
        public BlockFaceInfo Back => new("Cobblestone", typeof(Surface_Default));
        public BlockFaceInfo Right => new("Cobblestone", typeof(Surface_Default));
        public BlockFaceInfo Top => new("Cobblestone", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("Cobblestone", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Cobblestone";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
