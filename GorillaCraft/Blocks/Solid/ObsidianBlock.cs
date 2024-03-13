using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class ObsidianBlock : IBlock
    {
        public BlockFaceInfo Front => new("Obsidian", typeof(Surface_Default));
        public BlockFaceInfo Left => new("Obsidian", typeof(Surface_Default));
        public BlockFaceInfo Back => new("Obsidian", typeof(Surface_Default));
        public BlockFaceInfo Right => new("Obsidian", typeof(Surface_Default));
        public BlockFaceInfo Top => new("Obsidian", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("Obsidian", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Obsidian";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
