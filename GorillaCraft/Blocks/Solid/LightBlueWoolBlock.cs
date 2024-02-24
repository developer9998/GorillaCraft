using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    internal class LightBlueWoolBlock : IBlock
    {
        public BlockFaceInfo Front => new("LightBlueWool", typeof(Surface_Cloth));
        public BlockFaceInfo Left => new("LightBlueWool", typeof(Surface_Cloth));
        public BlockFaceInfo Back => new("LightBlueWool", typeof(Surface_Cloth));
        public BlockFaceInfo Right => new("LightBlueWool", typeof(Surface_Cloth));
        public BlockFaceInfo Up => new("LightBlueWool", typeof(Surface_Cloth));
        public BlockFaceInfo Down => new("LightBlueWool", typeof(Surface_Cloth));

        public Type PlaceSoundType => typeof(Interaction_Cloth);
        public Type DestroySoundType => typeof(Interaction_Cloth);

        public string BlockDefinition => "Light Blue Wool";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
