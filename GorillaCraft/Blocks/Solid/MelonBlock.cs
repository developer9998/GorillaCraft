using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class MelonBlock : IBlock
    {
        public BlockFaceInfo Front => new("MelonFace", typeof(Surface_Wood));
        public BlockFaceInfo Left => new("MelonFace", typeof(Surface_Wood));
        public BlockFaceInfo Back => new("MelonFace", typeof(Surface_Wood));
        public BlockFaceInfo Right => new("MelonFace", typeof(Surface_Wood));
        public BlockFaceInfo Top => new("MelonTop", typeof(Surface_Wood));
        public BlockFaceInfo Bottom => new("MelonTop", typeof(Surface_Wood));

        public Type PlaceSound => typeof(Interaction_Wood);
        public Type BreakSound => typeof(Interaction_Wood);

        public string Definition => "Melon";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.VerticalRotation_90;
    }
}
