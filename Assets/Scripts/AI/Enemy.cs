using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    
    public List<Transform> _pointTransform;
    public Transform _player;
    private bool _isPlayer = false;
    private float viewAngle = 65f;

    NavMeshAgent _agent;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        
        var direction = _player.position - transform.position;
        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, _player.position, out hit, 5f))
            {
                _isPlayer = true;
            }
        }
        else
        {
            _isPlayer = false;
        }
        Patrol();
    }
    private void Patrol()
    {
        if (_isPlayer) _agent.destination = _player.position;
        else
        {
            if (_agent.remainingDistance == _agent.stoppingDistance)
            {
                _agent.destination = _pointTransform[Random.Range(0, _pointTransform.Count)].position;
            }
        }
    }
   
}
