using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float _enemyHealth = 100;
    private Animator _animatorEnemy;
    private Enemy enemyController;
    NavMeshAgent _agent;

    void Start()
    {
        _animatorEnemy = GetComponent<Animator>();
        enemyController = GetComponent<Enemy>();
        _agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (_enemyHealth <= 0)
        {
            _animatorEnemy.SetTrigger("dieEnemy");
            enemyController.enabled = false;
            _agent.enabled = false;
            Invoke("KillEnemy", 5);
        }
    }
    private void KillEnemy() => Destroy(gameObject);
}
