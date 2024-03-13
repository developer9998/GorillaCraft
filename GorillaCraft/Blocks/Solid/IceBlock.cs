using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class IceBlock : IBlock
    {
        public BlockFaceInfo Front => new("Ice", typeof(Surface_Default));
        public BlockFaceInfo Left => new("Ice", typeof(Surface_Default));
        public BlockFaceInfo Back => new("Ice", typeof(Surface_Default));
        public BlockFaceInfo Right => new("Ice", typeof(Surface_Default));
        public BlockFaceInfo Top => new("Ice", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("Ice", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_BreakingGlass);

        public string BlockDefinition => "Ice";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
