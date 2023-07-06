using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Audio Manager is null!");
            }

            return _instance;
        }
    }

    [SerializeField] private AudioSource voiceOverSource;

    private void Awake()
    {
        _instance = this;
    }

    public void PlayVoiceOverClip(AudioClip audioClip)
    {
        voiceOverSource.clip = audioClip;
        voiceOverSource.Play();
    }
}
