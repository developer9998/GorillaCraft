using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class CobblestoneBlock : IBlock
    {
        public BlockFaceInfo Front => new("Cobblestone", typeof(Surface_Default));
        public BlockFaceInfo Left => new("Cobblestone", typeof(Surface_Default));
        public BlockFaceInfo Back => new("Cobblestone", typeof(Surface_Default));
        public BlockFaceInfo Right => new("Cobblestone", typeof(Surface_Default));
        public BlockFaceInfo Up => new("Cobblestone", typeof(Surface_Default));
        public BlockFaceInfo Down => new("Cobblestone", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Cobblestone";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
