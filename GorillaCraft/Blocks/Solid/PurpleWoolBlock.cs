using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class PurpleWoolBlock : IBlock
    {
        public BlockFaceInfo Front => new("PurpleWool", typeof(Surface_Cloth));
        public BlockFaceInfo Left => new("PurpleWool", typeof(Surface_Cloth));
        public BlockFaceInfo Back => new("PurpleWool", typeof(Surface_Cloth));
        public BlockFaceInfo Right => new("PurpleWool", typeof(Surface_Cloth));
        public BlockFaceInfo Top => new("PurpleWool", typeof(Surface_Cloth));
        public BlockFaceInfo Bottom => new("PurpleWool", typeof(Surface_Cloth));

        public Type PlaceSoundType => typeof(Interaction_Cloth);
        public Type DestroySoundType => typeof(Interaction_Cloth);

        public string BlockDefinition => "Purple Wool";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
