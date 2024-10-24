using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class BedrockBlock : IBlock
    {
        public BlockFaceInfo Front => new("Bedrock", typeof(Surface_Default));
        public BlockFaceInfo Left => new("Bedrock", typeof(Surface_Default));
        public BlockFaceInfo Back => new("Bedrock", typeof(Surface_Default));
        public BlockFaceInfo Right => new("Bedrock", typeof(Surface_Default));
        public BlockFaceInfo Top => new("Bedrock", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("Bedrock", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Bedrock";
        public BlockForm Form => BlockForm.Solid;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
