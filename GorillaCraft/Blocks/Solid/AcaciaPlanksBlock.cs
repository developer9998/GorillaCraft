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
        public BlockFaceInfo Top => new("AcaciaPlanks", typeof(Surface_Wood));
        public BlockFaceInfo Bottom => new("AcaciaPlanks", typeof(Surface_Wood));

        public Type PlaceSound => typeof(Interaction_Wood);
        public Type BreakSound => typeof(Interaction_Wood);

        public string Definition => "Acacia Planks";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
