using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    [SerializeField] private GameObject winCutscene;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance.HasCard)
            {
                GameManager.Instance.GameWon();
                winCutscene.SetActive(true);
            }
            else
            {
                print("You don't have card");
            }
        }
    }
}
