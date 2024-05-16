using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class PrismarineBricksBlock : IBlock
    {
        public BlockFaceInfo Front => new("PrismarineBricks", typeof(Surface_Default));
        public BlockFaceInfo Left => new("PrismarineBricks", typeof(Surface_Default));
        public BlockFaceInfo Back => new("PrismarineBricks", typeof(Surface_Default));
        public BlockFaceInfo Right => new("PrismarineBricks", typeof(Surface_Default));
        public BlockFaceInfo Top => new("PrismarineBricks", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("PrismarineBricks", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Prismarine Bricks";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
