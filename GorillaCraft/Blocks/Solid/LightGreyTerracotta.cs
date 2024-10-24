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

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Light Grey Terracotta";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
