using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Nonsolid
{
    public class AlliumBlock : IBlock
    {
        public BlockFaceInfo Front => new("Allium", typeof(Surface_Grass));
        public BlockFaceInfo Left => new("Allium", typeof(Surface_Grass));
        public BlockFaceInfo Back => new("Allium", typeof(Surface_Grass));
        public BlockFaceInfo Right => new("Allium", typeof(Surface_Grass));
        public BlockFaceInfo Top => new("Allium", typeof(Surface_Grass));
        public BlockFaceInfo Bottom => new("Allium", typeof(Surface_Grass));

        public Type PlaceSoundType => typeof(Interaction_Grass);
        public Type DestroySoundType => typeof(Interaction_Grass);

        public string BlockDefinition => "Allium";
        public BlockForm BlockForm => BlockForm.Decoration;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
