using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    
    private void Update()
    {
        transform.LookAt(playerTransform);
    }
}
