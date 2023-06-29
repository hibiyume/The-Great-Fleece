using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardTrigger : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCutscene; 
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameOverCutscene.SetActive(true);
        }
    }
}
