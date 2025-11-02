using GorillaCraft.Extensions;
using GorillaCraft.Interfaces;
using GorillaCraft.Models;
using GorillaCraft.Tools;
using UnityEngine;

namespace GorillaCraft.Utilities
{
    public static class SoundUtility
    {
        public static async void PlaySound(AssetLoader assetLoader, GameObject block, IDataType dataType, float volume)
        {
            RngObject randomSound = new(1, dataType.Range);

            string currentSound = string.Concat("Dig_", dataType.Name, randomSound.Get());
            AudioClip sound = await assetLoader.LoadAsset<AudioClip>(currentSound);

            AudioSource audioSource = block.GetOrAddComponent<AudioSource>();
            audioSource.spatialBlend = 1f;
            audioSource.clip = sound;
            audioSource.volume = dataType.Volume / 4f * volume;
            audioSource.pitch = dataType.Pitch;
            audioSource.Play();

            randomSound.Dispose();
            Object.Destroy(audioSource, sound.length);
        }
    }
}
