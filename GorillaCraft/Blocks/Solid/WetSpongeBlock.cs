using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class WetSpongeBlock : IBlock
    {
        public BlockFaceInfo Front => new("WetSponge", typeof(Surface_Grass));
        public BlockFaceInfo Left => new("WetSponge", typeof(Surface_Grass));
        public BlockFaceInfo Back => new("WetSponge", typeof(Surface_Grass));
        public BlockFaceInfo Right => new("WetSponge", typeof(Surface_Grass));
        public BlockFaceInfo Top => new("WetSponge", typeof(Surface_Grass));
        public BlockFaceInfo Bottom => new("WetSponge", typeof(Surface_Grass));

        public Type PlaceSound => typeof(Interaction_Grass);
        public Type BreakSound => typeof(Interaction_Grass);

        public string Definition => "Wet Sponge";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
