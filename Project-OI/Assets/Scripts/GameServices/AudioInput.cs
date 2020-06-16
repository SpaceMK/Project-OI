using System.Collections.Generic;
using UnityEngine;

public class AudioInput : IGameService
{
    AudioSource audioSource;
    Dictionary<AudioActionType, AudioClip> playbleAudio = new Dictionary<AudioActionType, AudioClip>();
    public AudioInput(AudioSource audio, Dictionary<AudioActionType, AudioClip> dic)
    {
        audioSource = audio;
        playbleAudio = dic;
    }

    public void PlayAudio(AudioActionType type)
    {
        audioSource.clip = playbleAudio[type];
        audioSource.Play();
    }
}

public enum AudioActionType
{
    PickUpWeapon
}
