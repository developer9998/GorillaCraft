using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class BrownWoolBlock : IBlock
    {
        public BlockFaceInfo Front => new("BrownWool", typeof(Surface_Cloth));
        public BlockFaceInfo Left => new("BrownWool", typeof(Surface_Cloth));
        public BlockFaceInfo Back => new("BrownWool", typeof(Surface_Cloth));
        public BlockFaceInfo Right => new("BrownWool", typeof(Surface_Cloth));
        public BlockFaceInfo Top => new("BrownWool", typeof(Surface_Cloth));
        public BlockFaceInfo Bottom => new("BrownWool", typeof(Surface_Cloth));

        public Type PlaceSoundType => typeof(Interaction_Cloth);
        public Type DestroySoundType => typeof(Interaction_Cloth);

        public string BlockDefinition => "Brown Wool";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
