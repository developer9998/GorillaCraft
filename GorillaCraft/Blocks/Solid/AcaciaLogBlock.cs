using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class AcaciaLogBlock : IBlock
    {
        public BlockFaceInfo Front => new("AcaciaLog", typeof(Surface_Wood));
        public BlockFaceInfo Left => new("AcaciaLog", typeof(Surface_Wood));
        public BlockFaceInfo Back => new("AcaciaLog", typeof(Surface_Wood));
        public BlockFaceInfo Right => new("AcaciaLog", typeof(Surface_Wood));
        public BlockFaceInfo Top => new("AcaciaLogTop", typeof(Surface_Wood));
        public BlockFaceInfo Bottom => new("AcaciaLogTop", typeof(Surface_Wood));

        public Type PlaceSound => typeof(Interaction_Wood);
        public Type BreakSound => typeof(Interaction_Wood);

        public string Definition => "Acacia Log";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.FullRotation;
    }
}
