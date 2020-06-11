using ServiceLocatorSample.ServiceLocator;
using System.Collections.Generic;
using UnityEngine;

public class CreateAudioInputInScene : MonoBehaviour
{ 
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] audioClips;
    Dictionary<AudioActionType, AudioClip> playbleAudio = new Dictionary<AudioActionType, AudioClip>();

    void Start()
    {
        LoadDictionary();        
    }

    void LoadDictionary()
    {
        playbleAudio.Add(AudioActionType.PickUpWeapon,audioClips[0]);
        ServiceLocator.Current.Register<AudioInput>(new AudioInput(audioSource,playbleAudio));
    }
}

