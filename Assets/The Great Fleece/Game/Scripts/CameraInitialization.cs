using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInitialization : MonoBehaviour
{
    [SerializeField] private Transform startPosition;

    private void Start()
    {
        transform.position = startPosition.position;
        transform.rotation = startPosition.rotation;
    }
}
