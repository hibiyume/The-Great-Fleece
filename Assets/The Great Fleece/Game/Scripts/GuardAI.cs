using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    [SerializeField] private List<Transform> wayPoints;
    [SerializeField] private Transform currentTarget;

    private NavMeshAgent _navMeshAgent;
    private int _prevWayPointIndex = 0;
    private bool _movingForward = true;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();

        if (wayPoints.Count > 0)
        {
            if (wayPoints[0] != null)
            {
                currentTarget = wayPoints[0];
                _navMeshAgent.SetDestination(currentTarget.position);
            }
        }
    }

    private void Update()
    {
        if (!_navMeshAgent.pathPending && _navMeshAgent.remainingDistance < 0.1f && wayPoints.Count > 0)
        {
            if (_prevWayPointIndex == wayPoints.Count - 1)
                _movingForward = false;
            else if (_prevWayPointIndex == 0)
                _movingForward = true;
            
            int newWaypointIndex;
            if (_movingForward)
                newWaypointIndex = _prevWayPointIndex + 1;
            else
                newWaypointIndex = _prevWayPointIndex - 1;

            currentTarget = wayPoints[newWaypointIndex]; 
            _navMeshAgent.SetDestination(currentTarget.position);

            _prevWayPointIndex = newWaypointIndex;
        }
    }
}