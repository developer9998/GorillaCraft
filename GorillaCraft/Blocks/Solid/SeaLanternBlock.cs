using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class SeaLanternBlock : IBlock
    {
        public BlockFaceInfo Front => new("SeaLantern", typeof(Surface_Default));
        public BlockFaceInfo Left => new("SeaLantern", typeof(Surface_Default));
        public BlockFaceInfo Back => new("SeaLantern", typeof(Surface_Default));
        public BlockFaceInfo Right => new("SeaLantern", typeof(Surface_Default));
        public BlockFaceInfo Top => new("SeaLantern", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("SeaLantern", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_BreakingGlass);

        public string BlockDefinition => "Sea Lantern";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
