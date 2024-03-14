using UnityEngine;

public class GranateDamage : MonoBehaviour
{
    public int delay = 2;
    public Rigidbody _rb;
    [SerializeField] private GameObject _zoneGranade;
    private bool _isBoom = false;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Invoke("TimeZone", delay);
    }
    public void TimeZone()
    {
        /*var component = transform.GetComponent<MeshRenderer>();
        component.enabled = false;*/
        Destroy(gameObject);
        Instantiate(_zoneGranade, transform.position, Quaternion.identity);
        //_zoneGranade.transform.localScale =  Vector3.Lerp(new Vector3(0,0,0), new Vector3(1, 1, 1), Time.deltaTime) * Time.deltaTime;
    }

}
