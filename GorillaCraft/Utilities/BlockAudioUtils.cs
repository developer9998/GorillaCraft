using GorillaCraft.Extensions;
using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using UnityEngine;

namespace GorillaCraft.Utilities
{
    public static class BlockAudioUtils
    {
        public static async void PlaySound(AssetLoader assetLoader, GameObject block, IDataType dataType)
        {
            RngObject randomSound = new(1, dataType.MaxRange);

            string currentSound = string.Concat("Dig_", dataType.Name, randomSound.Get());
            AudioClip sound = await assetLoader.LoadAsset<AudioClip>(currentSound);

            AudioSource audioSource = block.GetOrAddComponent<AudioSource>();
            audioSource.spatialBlend = 1f;
            audioSource.clip = sound;
            audioSource.volume = dataType.Volume / 4f;
            audioSource.pitch = dataType.Pitch;
            audioSource.Play();

            randomSound.Dispose();
            Object.Destroy(audioSource, sound.length);
        }
    }
}
