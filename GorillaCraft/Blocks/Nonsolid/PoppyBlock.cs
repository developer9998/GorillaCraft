using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Nonsolid
{
    public class PoppyBlock : IBlock
    {
        public BlockFaceInfo Front => new("Poppy", typeof(Surface_Grass));
        public BlockFaceInfo Left => new("Poppy", typeof(Surface_Grass));
        public BlockFaceInfo Back => new("Poppy", typeof(Surface_Grass));
        public BlockFaceInfo Right => new("Poppy", typeof(Surface_Grass));
        public BlockFaceInfo Up => new("Poppy", typeof(Surface_Grass));
        public BlockFaceInfo Down => new("Poppy", typeof(Surface_Grass));

        public Type PlaceSoundType => typeof(Interaction_Grass);
        public Type DestroySoundType => typeof(Interaction_Grass);

        public string BlockDefinition => "Poppy";
        public BlockForm BlockForm => BlockForm.Decoration;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
