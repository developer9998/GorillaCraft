using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class JunglePlanksBlock : IBlock
    {
        public BlockFaceInfo Front => new("JunglePlanks", typeof(Surface_Wood));
        public BlockFaceInfo Left => new("JunglePlanks", typeof(Surface_Wood));
        public BlockFaceInfo Back => new("JunglePlanks", typeof(Surface_Wood));
        public BlockFaceInfo Right => new("JunglePlanks", typeof(Surface_Wood));
        public BlockFaceInfo Up => new("JunglePlanks", typeof(Surface_Wood));
        public BlockFaceInfo Down => new("JunglePlanks", typeof(Surface_Wood));

        public Type PlaceSoundType => typeof(Interaction_Wood);
        public Type DestroySoundType => typeof(Interaction_Wood);

        public string BlockDefinition => "Jungle Planks";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
