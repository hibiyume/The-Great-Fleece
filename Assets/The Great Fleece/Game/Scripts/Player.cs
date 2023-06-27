using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;

    private Vector3 target;
    
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
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
                target = hit.point;
                _navMeshAgent.SetDestination(target);
                _animator.SetBool("Walk", true);
            }
        }
        
        if (!_navMeshAgent.pathPending && _navMeshAgent.remainingDistance < 0.1f)
        {
            _animator.SetBool("Walk", false);
        }
    }
}
