using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepingGuardTrigger : MonoBehaviour
{
    [SerializeField] private GameObject sleepingGuardCutscene;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sleepingGuardCutscene.SetActive(true);
        }
    }
}
