using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speedBullet = 50;
    [SerializeField] private float damage = 10;
    public float liveBullet = 10;

    private void Update()=> Invoke("DestroyThis", liveBullet);

    void FixedUpdate()=>MoveBullet();
    private void MoveBullet()=> transform.position += transform.forward * speedBullet * Time.fixedDeltaTime;
    private void OnTriggerEnter(Collider other)
    {
        DamegeEmeny(other);
        DestroyThis();
    }
    private void DamegeEmeny(Collider other)
    {
        var enemy = other.gameObject.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy._enemyHealth -= damage;
        }
    }
    private void DestroyThis() => Destroy(gameObject);
}
