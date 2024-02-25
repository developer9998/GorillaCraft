using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class NetherrackBlock : IBlock
    {
        public BlockFaceInfo Front => new("Netherrack", typeof(Surface_Default));
        public BlockFaceInfo Left => new("Netherrack", typeof(Surface_Default));
        public BlockFaceInfo Back => new("Netherrack", typeof(Surface_Default));
        public BlockFaceInfo Right => new("Netherrack", typeof(Surface_Default));
        public BlockFaceInfo Up => new("Netherrack", typeof(Surface_Default));
        public BlockFaceInfo Down => new("Netherrack", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Netherrack";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
