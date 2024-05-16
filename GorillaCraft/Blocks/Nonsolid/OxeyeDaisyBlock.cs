using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Nonsolid
{
    public class OxeyeDaisyBlock : IBlock
    {
        public BlockFaceInfo Front => new("Oxeye Daisy", typeof(Surface_Grass));
        public BlockFaceInfo Left => new("Oxeye Daisy", typeof(Surface_Grass));
        public BlockFaceInfo Back => new("Oxeye Daisy", typeof(Surface_Grass));
        public BlockFaceInfo Right => new("Oxeye Daisy", typeof(Surface_Grass));
        public BlockFaceInfo Top => new("Oxeye Daisy", typeof(Surface_Grass));
        public BlockFaceInfo Bottom => new("Oxeye Daisy", typeof(Surface_Grass));

        public Type PlaceSoundType => typeof(Interaction_Grass);
        public Type DestroySoundType => typeof(Interaction_Grass);

        public string BlockDefinition => "Oxeye Daisy";
        public BlockForm BlockForm => BlockForm.Decoration;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
