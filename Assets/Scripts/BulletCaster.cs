using UnityEngine;

public class BulletCaster : MonoBehaviour
{
    [SerializeField] private Transform _pricel;
    [SerializeField] private Transform _pricelGranate;


    public Transform targetPricel;
    public float targetPricelSky;
    public bool _isShoot = true;


    [SerializeField] private GameObject _bullet;

    public Camera cameraPlayer;

    void Update()
    {
        if (_isShoot)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //_bullet.transform.rotation = _pricel.rotation;
                Instantiate(_bullet, _pricel.position, _pricel.rotation);
            }
            var ray = cameraPlayer.ViewportPointToRay(new Vector3(0.5f, 0.7f, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                targetPricel.position = hit.point;
            }
            else
            {
                targetPricel.position = ray.GetPoint(targetPricelSky);
            }
            _pricel.LookAt(targetPricel.position);
        }
        _pricelGranate.LookAt(targetPricel.position);
    }
}
