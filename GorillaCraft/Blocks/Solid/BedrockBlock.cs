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

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Bedrock";
        public BlockForm BlockForm => BlockForm.Solid;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
