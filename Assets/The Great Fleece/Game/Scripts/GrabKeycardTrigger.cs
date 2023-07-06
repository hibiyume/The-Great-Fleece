using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKeycardTrigger : MonoBehaviour
{
    [SerializeField] private GameObject sleepingGuardCutscene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !GameManager.Instance.HasCard)
        {
            sleepingGuardCutscene.SetActive(true);
            GameManager.Instance.HasCard = true;
        }
    }
}