using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class AcaciaPlanksBlock : IBlock
    {
        public BlockFaceInfo Front => new("AcaciaPlanks", typeof(Surface_Wood));
        public BlockFaceInfo Left => new("AcaciaPlanks", typeof(Surface_Wood));
        public BlockFaceInfo Back => new("AcaciaPlanks", typeof(Surface_Wood));
        public BlockFaceInfo Right => new("AcaciaPlanks", typeof(Surface_Wood));
        public BlockFaceInfo Up => new("AcaciaPlanks", typeof(Surface_Wood));
        public BlockFaceInfo Down => new("AcaciaPlanks", typeof(Surface_Wood));

        public Type PlaceSoundType => typeof(Interaction_Wood);
        public Type DestroySoundType => typeof(Interaction_Wood);

        public string BlockDefinition => "Acacia Planks";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
