using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{
    private AudioSource _audioSource;
    private bool _isPlayed;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_isPlayed)
        {
            _audioSource.Play();
            _isPlayed = true;
        }
    }
}
