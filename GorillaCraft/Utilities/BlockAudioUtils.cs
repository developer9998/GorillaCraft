using GorillaCraft.Extensions;
using GorillaCraft.Interfaces;
using UnityEngine;

namespace GorillaCraft.Utilities
{
    public static class BlockAudioUtils
    {
        public static async void PlaySound(AssetLoader assetLoader, GameObject block, IDataType dataType)
        {
            string currentSound = string.Concat("Dig_", dataType.Name, Random.Range(1, dataType.MaxRange));
            AudioClip sound = await assetLoader.LoadAsset<AudioClip>(currentSound);

            AudioSource audioSource = block.GetOrAddComponent<AudioSource>();
            audioSource.spatialBlend = 1f;
            audioSource.clip = sound;
            audioSource.volume = dataType.Volume / 4f;
            audioSource.pitch = dataType.Pitch;
            audioSource.Play();

            Object.Destroy(audioSource, sound.length);
        }
    }
}
