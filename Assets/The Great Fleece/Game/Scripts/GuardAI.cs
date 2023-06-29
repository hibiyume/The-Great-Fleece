using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class GuardAI : MonoBehaviour
{
    [SerializeField] private List<Transform> wayPoints;
    [SerializeField] private float minIdleDelay = 2f;
    [SerializeField] private float maxIdleDelay = 4f;

    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    private int _currentTarget;
    private bool _movingForward = true;
    private bool _targetReached = false;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();

        if (wayPoints.Count > 0)
        {
            if (wayPoints[0] != null)
            {
                _navMeshAgent.SetDestination(wayPoints[_currentTarget].position);
            }
        }
    }

    private void Update()
    {
        if (!_navMeshAgent.pathPending && _navMeshAgent.remainingDistance < 0.1f && wayPoints.Count > 0 && !_targetReached)
        {
            _targetReached = true;
            _animator.SetBool("Walk", false);
            StartCoroutine(MoveToNextWaypoint());
        }
    }
    IEnumerator MoveToNextWaypoint()
    {
        yield return new WaitForSeconds(Random.Range(minIdleDelay, maxIdleDelay));
        
        if (_currentTarget == 0)
            _movingForward = true;
        else if (_currentTarget == wayPoints.Count - 1)
            _movingForward = false;

        if (_movingForward)
            _currentTarget++;
        else
            _currentTarget--;
        
        _navMeshAgent.SetDestination(wayPoints[_currentTarget].position);
        _targetReached = false;
        _animator.SetBool("Walk", true);
    }
}