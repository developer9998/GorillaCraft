using UnityEngine;
using UnityEngine.Serialization;

namespace GorillaCraft.Models
{
    [CreateAssetMenu(fileName = "Block", menuName = "GorillaCraft/Block")]
    public class BlockObject : ScriptableObject
    {
        public string Definition;

        [FormerlySerializedAs("BlockID")]
        public short BlockId;

        [Space]

        public BlockForm Form;

        public BlockPlacement Placement;

        [Header("Sounds")]

        public BlockSoundObject PlaceSound;

        public BlockSoundObject BreakSound;

        [Header("Faces")]

        public BlockFaceObject Base;

        public BlockFaceObject Front;

        public BlockFaceObject Back;

        public BlockFaceObject Left;

        public BlockFaceObject Right;

        public BlockFaceObject Top;

        public BlockFaceObject Bottom;
    }
}
