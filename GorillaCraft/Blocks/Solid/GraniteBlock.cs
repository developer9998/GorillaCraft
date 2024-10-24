using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class GraniteBlock : IBlock
    {
        public BlockFaceInfo Front => new("Granite", typeof(Surface_Default));
        public BlockFaceInfo Left => new("Granite", typeof(Surface_Default));
        public BlockFaceInfo Back => new("Granite", typeof(Surface_Default));
        public BlockFaceInfo Right => new("Granite", typeof(Surface_Default));
        public BlockFaceInfo Top => new("Granite", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("Granite", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Granite";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
