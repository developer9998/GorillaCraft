using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class NoteBlock : IBlock
    {
        public BlockFaceInfo Front => new("JukeboxSide", typeof(Surface_Default));
        public BlockFaceInfo Left => new("JukeboxSide", typeof(Surface_Default));
        public BlockFaceInfo Back => new("JukeboxSide", typeof(Surface_Default));
        public BlockFaceInfo Right => new("JukeboxSide", typeof(Surface_Default));
        public BlockFaceInfo Top => new("JukeboxSide", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("JukeboxSide", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Note Block";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
