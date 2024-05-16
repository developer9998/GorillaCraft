using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class CrackedStoneBrickBlock : IBlock
    {
        public BlockFaceInfo Front => new("CrackedStoneBrick", typeof(Surface_Default));
        public BlockFaceInfo Left => new("CrackedStoneBrick", typeof(Surface_Default));
        public BlockFaceInfo Back => new("CrackedStoneBrick", typeof(Surface_Default));
        public BlockFaceInfo Right => new("CrackedStoneBrick", typeof(Surface_Default));
        public BlockFaceInfo Top => new("CrackedStoneBrick", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("CrackedStoneBrick", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Cracked Stone Bricks";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
