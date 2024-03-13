using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class StoneBlock : IBlock
    {
        public BlockFaceInfo Front => new("Stone", typeof(Surface_Default));
        public BlockFaceInfo Left => new("Stone", typeof(Surface_Default));
        public BlockFaceInfo Back => new("Stone", typeof(Surface_Default));
        public BlockFaceInfo Right => new("Stone", typeof(Surface_Default));
        public BlockFaceInfo Top => new("Stone", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("Stone", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Stone";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
