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
        public BlockFaceInfo Up => new("Sponge", typeof(Surface_Grass));
        public BlockFaceInfo Down => new("Sponge", typeof(Surface_Grass));

        public Type PlaceSoundType => typeof(Interaction_Grass);
        public Type DestroySoundType => typeof(Interaction_Grass);

        public string BlockDefinition => "Sponge";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
