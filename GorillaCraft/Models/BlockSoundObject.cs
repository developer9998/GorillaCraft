using UnityEngine;

namespace GorillaCraft.Models
{
    [CreateAssetMenu(fileName = "Block Sound", menuName = "GorillaCraft/Block Sound")]
    public class BlockSoundObject : ScriptableObject
    {
        public byte SoundId;

        [Space]

        public AudioClip[] Audio;

        public float Volume;

        public float Pitch;
    }
}
