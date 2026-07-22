using UnityEngine;

namespace GorillaCraft.Models
{
    [CreateAssetMenu(fileName = "Block Face", menuName = "GorillaCraft/Block Face")]
    public class BlockFaceObject : ScriptableObject
    {
        public Material Material;

        public PhysicsMaterial PhysicMaterial;

        public int SurfaceOverride = -1;

        public BlockSoundObject TapSound;
    }
}