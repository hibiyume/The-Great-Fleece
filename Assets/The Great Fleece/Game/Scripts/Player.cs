using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //if left click
        if (Input.GetMouseButtonDown(0))
        {
            //cast a ray from mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit))
            {
                _navMeshAgent.SetDestination(hit.point);
            }
        }
        //debug the floor position hit
        //create object at floor position
    }
}
