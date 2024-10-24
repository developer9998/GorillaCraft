using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class JukeboxBlock : IBlock
    {
        public BlockFaceInfo Front => new("JukeboxSide", typeof(Surface_Default));
        public BlockFaceInfo Left => new("JukeboxSide", typeof(Surface_Default));
        public BlockFaceInfo Back => new("JukeboxSide", typeof(Surface_Default));
        public BlockFaceInfo Right => new("JukeboxSide", typeof(Surface_Default));
        public BlockFaceInfo Top => new("JukeboxTop", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("JukeboxSide", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Jukebox";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
