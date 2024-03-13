using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Nonsolid
{
    public class BrownMushroomBlock : IBlock
    {
        public BlockFaceInfo Front => new("BrownMush", typeof(Surface_Grass));
        public BlockFaceInfo Left => new("BrownMush", typeof(Surface_Grass));
        public BlockFaceInfo Back => new("BrownMush", typeof(Surface_Grass));
        public BlockFaceInfo Right => new("BrownMush", typeof(Surface_Grass));
        public BlockFaceInfo Top => new("BrownMush", typeof(Surface_Grass));
        public BlockFaceInfo Bottom => new("BrownMush", typeof(Surface_Grass));

        public Type PlaceSoundType => typeof(Interaction_Grass);
        public Type DestroySoundType => typeof(Interaction_Grass);

        public string BlockDefinition => "Brown Mushroom";
        public BlockForm BlockForm => BlockForm.Decoration;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
