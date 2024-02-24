using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Sounds;
using System;
using System.Collections.Generic;
using System.Text;

namespace GorillaCraft.Blocks.Solid
{
    public class MobSpawnerBlock : IBlock
    {
        public BlockFaceInfo Front => new("Spawner", typeof(Surface_Default));
        public BlockFaceInfo Left => new("Spawner", typeof(Surface_Default));
        public BlockFaceInfo Back => new("Spawner", typeof(Surface_Default));
        public BlockFaceInfo Right => new("Spawner", typeof(Surface_Default));
        public BlockFaceInfo Up => new("Spawner", typeof(Surface_Default));
        public BlockFaceInfo Down => new("Spawner", typeof(Surface_Default));

        public Type PlaceSoundType => typeof(Interaction_Default);
        public Type DestroySoundType => typeof(Interaction_Default);

        public string BlockDefinition => "Mob Spawner";
        public BlockForm BlockForm => BlockForm.Solid_OtherDev;
        public BlockPlacement BlockPlacement => BlockPlacement.Default;
    }
}
