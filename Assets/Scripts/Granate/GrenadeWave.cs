using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeWave : MonoBehaviour
{
    public int delay = 2;
    public float damage = 20;
    public float maxSize = 5;
    public float speedBoom = 5;
    private void Start()
    {
        transform.localScale = Vector3.zero;
    }
    void Update()
    {
        transform.localScale += Vector3.one * Time.deltaTime* speedBoom;
        //Invoke("DestroyGameObject", delay);
        if (transform.localScale.x >= maxSize && transform.localScale.y >= maxSize && transform.localScale.z >= maxSize)
        {
            DestroyGameObject();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            var playerHelth = other.GetComponent<PlayerHelth>();
            if (playerHelth != null) playerHelth._playerHealth -= damage;
        }
        if (other.gameObject.tag == "Enemy")
        {
            var enemy = other.GetComponent<EnemyHealth>();
            if (enemy != null) enemy._enemyHealth -= damage;
        }
    }
    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
