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
        public BlockFaceInfo Up => new("RedMush", typeof(Surface_Grass));
        public BlockFaceInfo Down => new("RedMush", typeof(Surface_Grass));

        public Type PlaceSoundType => typeof(Interaction_Grass);
        public Type DestroySoundType => typeof(Interaction_Grass);

        public string BlockDefinition => "Red Mushroom";
        public BlockForm BlockForm => BlockForm.Nonsolid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
