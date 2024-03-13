using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Nonsolid
{
    public class DandelionBlock : IBlock
    {
        public BlockFaceInfo Front => new("Dandelion", typeof(Surface_Grass));
        public BlockFaceInfo Left => new("Dandelion", typeof(Surface_Grass));
        public BlockFaceInfo Back => new("Dandelion", typeof(Surface_Grass));
        public BlockFaceInfo Right => new("Dandelion", typeof(Surface_Grass));
        public BlockFaceInfo Top => new("Dandelion", typeof(Surface_Grass));
        public BlockFaceInfo Bottom => new("Dandelion", typeof(Surface_Grass));

        public Type PlaceSoundType => typeof(Interaction_Grass);
        public Type DestroySoundType => typeof(Interaction_Grass);

        public string BlockDefinition => "Dandelion";
        public BlockForm BlockForm => BlockForm.Decoration;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
