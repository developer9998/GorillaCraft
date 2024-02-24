using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class TNTBlock : IBlock
    {
        public BlockFaceInfo Front => new("TNTFront", typeof(Surface_Grass));
        public BlockFaceInfo Left => new("TNTFront", typeof(Surface_Grass));
        public BlockFaceInfo Back => new("TNTFront", typeof(Surface_Grass));
        public BlockFaceInfo Right => new("TNTFront", typeof(Surface_Grass));
        public BlockFaceInfo Up => new("TNTTop", typeof(Surface_Grass));
        public BlockFaceInfo Down => new("TNTBottom", typeof(Surface_Grass));

        public Type PlaceSoundType => typeof(Interaction_Grass);
        public Type DestroySoundType => typeof(Interaction_Grass);

        public string BlockDefinition => "TNT";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
