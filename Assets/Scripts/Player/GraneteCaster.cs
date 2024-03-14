using UnityEngine;

public class GraneteCaster : MonoBehaviour
{
    [SerializeField] private Transform _pricelGranate;
    [SerializeField] private GameObject _grenadePrefab;
    [SerializeField] private Rigidbody _grenadeRig;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            var granete = Instantiate(_grenadePrefab);
            granete.transform.position = _pricelGranate.transform.position;
            // granete.transform.rotation = Quaternion.Euler(_pricelGranate.rotation.x - 35f, _pricelGranate.rotation.y, _pricelGranate.rotation.z);
            granete.GetComponent<Rigidbody>().AddForce(_pricelGranate.forward * 500);
            // granate._rb.AddForce(Vector3.forward * 1000 * Time.deltaTime);
        }
        //_grenade.transform.rotation = Quaternion.Euler(_pricel.rotation.x, _pricel.rotation.y, _pricel.rotation.z);
        /*     Instantiate(_grenade, _pricel.position, Quaternion.Euler(_pricel.rotation.x - 35f , _pricel.rotation.y, _pricel.rotation.z));
             _grenade.GetComponent<GranateDamage>()._rb.AddForce(_pricel.forward * 500 );*/
    }
}

