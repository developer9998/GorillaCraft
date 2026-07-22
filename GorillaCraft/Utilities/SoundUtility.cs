using GorillaCraft.Models;
using UnityEngine;

namespace GorillaCraft.Utilities;

public static class SoundUtility
{
    public static async void PlaySound(GameObject block, BlockSoundObject dataType, float volume)
    {
        AudioClip audio = dataType.Audio[Random.Range(0, dataType.Audio.Length)];
        AudioSource audioSource = block.AddComponent<AudioSource>();
        audioSource.spatialBlend = 1f;
        audioSource.clip = audio;
        audioSource.volume = dataType.Volume / 4f * volume;
        audioSource.pitch = dataType.Pitch;
        audioSource.Play();
        Object.Destroy(audioSource, audio.length);
    }
}
