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

        public Type PlaceSoundType => typeof(Interaction_Wood);
        public Type DestroySoundType => typeof(Interaction_Wood);

        public string BlockDefinition => "Melon";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.VerticalRotation_90;
    }
}
