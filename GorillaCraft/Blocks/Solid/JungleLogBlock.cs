using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class JungleLogBlock : IBlock
    {
        public BlockFaceInfo Front => new("JungleLog", typeof(Surface_Wood));
        public BlockFaceInfo Left => new("JungleLog", typeof(Surface_Wood));
        public BlockFaceInfo Back => new("JungleLog", typeof(Surface_Wood));
        public BlockFaceInfo Right => new("JungleLog", typeof(Surface_Wood));
        public BlockFaceInfo Top => new("JungleLogTop", typeof(Surface_Wood));
        public BlockFaceInfo Bottom => new("JungleLogTop", typeof(Surface_Wood));

        public Type PlaceSoundType => typeof(Interaction_Wood);
        public Type DestroySoundType => typeof(Interaction_Wood);

        public string BlockDefinition => "Jungle Log";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.FullRotation;
    }
}
