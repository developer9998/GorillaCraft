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
        public BlockFaceInfo Up => new("Snow", typeof(Surface_Snow));
        public BlockFaceInfo Down => new("Snow", typeof(Surface_Snow));

        public Type PlaceSoundType => typeof(Interaction_Snow);
        public Type DestroySoundType => typeof(Interaction_Snow);

        public string BlockDefinition => "Snow Block";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
