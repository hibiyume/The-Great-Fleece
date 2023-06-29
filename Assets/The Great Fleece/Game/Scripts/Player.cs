using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    
    private Vector3 _target;
    private bool _coinTossed = false;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //cast a ray from mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit))
            {
                _target = hit.point;
                _navMeshAgent.SetDestination(_target);
                _animator.SetBool("Walk", true);
            }
        }
        
        if (!_navMeshAgent.pathPending && _navMeshAgent.remainingDistance < 0.1f)
        {
            _animator.SetBool("Walk", false);
        }
        
        if (Input.GetMouseButtonDown(1) && !_coinTossed)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit))
            {
                GameObject coin = Instantiate(coinPrefab, hit.point, Quaternion.identity);
                coin.GetComponentInChildren<AudioSource>().Play();
                MoveGuardsToCoin(coin.transform.position);
                _coinTossed = true;
            }
        }
    }

    void MoveGuardsToCoin(Vector3 coinPosition)
    {
        var guards = GameObject.FindGameObjectsWithTag("Guard1");

        foreach (var guard in guards)
        {
            StartCoroutine(guard.GetComponent<GuardAI>().MoveToNextSpot(coinPosition));
        }
    }
}
