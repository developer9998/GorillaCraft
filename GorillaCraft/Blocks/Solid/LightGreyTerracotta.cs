using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class LightGreyTerracotta : IBlock
    {
        public BlockFaceInfo Front => new("LGTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Left => new("LGTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Back => new("LGTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Right => new("LGTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Top => new("LGTerracotta", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("LGTerracotta", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Light Grey Terracotta";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
