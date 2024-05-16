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

        public Type PlaceSoundType => typeof(Interaction_Sand);
        public Type DestroySoundType => typeof(Interaction_Sand);

        public string BlockDefinition => "Red Sand";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
