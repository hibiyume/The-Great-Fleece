using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;
    private bool _isPlayed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_isPlayed)
        {
            AudioManager.Instance.PlayVoiceOver(_audioClip);
            _isPlayed = true;
        }
    }
}
