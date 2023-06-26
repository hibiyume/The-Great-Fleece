using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    //Check for trigger of player
    //update main camera to appropriate angle

    [SerializeField] private Transform cameraTransform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print($"{gameObject.name} triggered");
            Camera.main.transform.position = cameraTransform.position;
            Camera.main.transform.rotation = cameraTransform.rotation;
        }
    }
}
