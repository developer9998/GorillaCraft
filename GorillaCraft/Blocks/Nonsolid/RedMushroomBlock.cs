using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Nonsolid
{
    public class RedMushroomBlock : IBlock
    {
        public BlockFaceInfo Front => new("RedMush", typeof(Surface_Grass));
        public BlockFaceInfo Left => new("RedMush", typeof(Surface_Grass));
        public BlockFaceInfo Back => new("RedMush", typeof(Surface_Grass));
        public BlockFaceInfo Right => new("RedMush", typeof(Surface_Grass));
        public BlockFaceInfo Top => new("RedMush", typeof(Surface_Grass));
        public BlockFaceInfo Bottom => new("RedMush", typeof(Surface_Grass));

        public Type PlaceSound => typeof(Interaction_Grass);
        public Type BreakSound => typeof(Interaction_Grass);

        public string Definition => "Red Mushroom";
        public BlockForm Form => BlockForm.Decoration;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
