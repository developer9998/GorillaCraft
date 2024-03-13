using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class BirchLogBlock : IBlock
    {
        public BlockFaceInfo Front => new("BirchLog", typeof(Surface_Wood));
        public BlockFaceInfo Left => new("BirchLog", typeof(Surface_Wood));
        public BlockFaceInfo Back => new("BirchLog", typeof(Surface_Wood));
        public BlockFaceInfo Right => new("BirchLog", typeof(Surface_Wood));
        public BlockFaceInfo Top => new("BirchLogTop", typeof(Surface_Wood));
        public BlockFaceInfo Bottom => new("BirchLogTop", typeof(Surface_Wood));

        public Type PlaceSoundType => typeof(Interaction_Wood);
        public Type DestroySoundType => typeof(Interaction_Wood);

        public string BlockDefinition => "Birch Log";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.FullRotation;
    }
}
