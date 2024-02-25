using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float _enemyHealth = 100;

    void Update()
    {
        if (_enemyHealth <= 0) KillEnemy();
    }
    private void KillEnemy() => Destroy(gameObject);
}
