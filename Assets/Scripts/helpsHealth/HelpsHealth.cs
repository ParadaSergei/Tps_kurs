using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpsHealth : MonoBehaviour
{
    private float _healthValue = 20f;
   
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerHelth>();
        if (player != null)
        {
            player._playerHealth += _healthValue;
            player._playerHealth = Mathf.Clamp(player._playerHealth, 0, 100);
            Destroy(gameObject);
        }
    }
}
