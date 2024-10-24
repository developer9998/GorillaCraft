using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    internal class SnowBlock : IBlock
    {
        public BlockFaceInfo Front => new("Snow", typeof(Surface_Snow));
        public BlockFaceInfo Left => new("Snow", typeof(Surface_Snow));
        public BlockFaceInfo Back => new("Snow", typeof(Surface_Snow));
        public BlockFaceInfo Right => new("Snow", typeof(Surface_Snow));
        public BlockFaceInfo Top => new("Snow", typeof(Surface_Snow));
        public BlockFaceInfo Bottom => new("Snow", typeof(Surface_Snow));

        public Type PlaceSound => typeof(Interaction_Snow);
        public Type BreakSound => typeof(Interaction_Snow);

        public string Definition => "Snow Block";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
