using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class NetherrackBlock : IBlock
    {
        public BlockFaceInfo Front => new("Netherrack", typeof(Surface_Default));
        public BlockFaceInfo Left => new("Netherrack", typeof(Surface_Default));
        public BlockFaceInfo Back => new("Netherrack", typeof(Surface_Default));
        public BlockFaceInfo Right => new("Netherrack", typeof(Surface_Default));
        public BlockFaceInfo Top => new("Netherrack", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("Netherrack", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Netherrack";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
