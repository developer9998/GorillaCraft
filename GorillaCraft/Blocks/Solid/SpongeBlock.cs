using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class SpongeBlock : IBlock
    {
        public BlockFaceInfo Front => new("Sponge", typeof(Surface_Grass));
        public BlockFaceInfo Left => new("Sponge", typeof(Surface_Grass));
        public BlockFaceInfo Back => new("Sponge", typeof(Surface_Grass));
        public BlockFaceInfo Right => new("Sponge", typeof(Surface_Grass));
        public BlockFaceInfo Top => new("Sponge", typeof(Surface_Grass));
        public BlockFaceInfo Bottom => new("Sponge", typeof(Surface_Grass));

        public Type PlaceSound => typeof(Interaction_Grass);
        public Type BreakSound => typeof(Interaction_Grass);

        public string Definition => "Sponge";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
