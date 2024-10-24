using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;

namespace GorillaCraft.Blocks.Solid
{
    public class MobSpawnerBlock : IBlock
    {
        public BlockFaceInfo Front => new("Spawner", typeof(Surface_Default));
        public BlockFaceInfo Left => new("Spawner", typeof(Surface_Default));
        public BlockFaceInfo Back => new("Spawner", typeof(Surface_Default));
        public BlockFaceInfo Right => new("Spawner", typeof(Surface_Default));
        public BlockFaceInfo Top => new("Spawner", typeof(Surface_Default));
        public BlockFaceInfo Bottom => new("Spawner", typeof(Surface_Default));

        public Type PlaceSound => typeof(Interaction_Default);
        public Type BreakSound => typeof(Interaction_Default);

        public string Definition => "Monster Spawner";
        public BlockForm Form => BlockForm.DevSpawner;
        public BlockPlacement Placement => BlockPlacement.Default;
    }
}
