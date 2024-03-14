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
    public float damage = 10f;
    private Animator _animatorEnemy;
    private int moveAnim = 0;

    NavMeshAgent _agent;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animatorEnemy = GetComponent<Animator>();
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
        _animatorEnemy.SetInteger("move", moveAnim);

    }
    private void Patrol()
    {

        if (_isPlayer)
        {
            _agent.destination = _player.position;
        }
        else
        {
            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                _agent.destination = _pointTransform[Random.Range(0, _pointTransform.Count)].position;
                moveAnim = 1;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            var playerHelth = other.GetComponent<PlayerHelth>();
            if (playerHelth != null) playerHelth.initializationDamage(damage, true);
            moveAnim = 2;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            var playerHelth = other.GetComponent<PlayerHelth>();
            if (playerHelth != null) playerHelth.initializationDamage(damage, false);
        }
    }

}
