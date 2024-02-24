using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class IronOreBlock : IBlock
    {
        public BlockFaceInfo Front => new("IronOre", typeof(Surface_Default));
        public BlockFaceInfo Left => new("IronOre", typeof(Surface_Default));
        public BlockFaceInfo Back => new("IronOre", typeof(Surface_Default));
        public BlockFaceInfo Right => new("IronOre", typeof(Surface_Default));
        public BlockFaceInfo Up => new("IronOre", typeof(Surface_Default));
        public BlockFaceInfo Down => new("IronOre", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Iron Ore";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
