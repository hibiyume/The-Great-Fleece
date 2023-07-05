using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCutscene;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameOverCutscene.SetActive(true);
        }
    }
}
