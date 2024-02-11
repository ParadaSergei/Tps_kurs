using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 15f;
    [SerializeField] private Transform _CameraAxis;
    [SerializeField] private float _fallVelocity = 0f;
    [SerializeField] private float gravity = 9.8f;
    private Vector3 _movePlayer;
    private float _speedMove = 5f;
    public float jumpForce = 5f;
    private float _mouseX;
    private float _mouseY;
    private CharacterController _playerCollider;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _playerCollider = GetComponent<CharacterController>();
        _movePlayer = Vector3.zero;
    }

    void Update()
    {
        _mouseY = Input.GetAxis("Mouse Y");
        _mouseX = Input.GetAxis("Mouse X");
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + Time.deltaTime * _mouseX * _rotationSpeed, 0);

        float rotY = _CameraAxis.localEulerAngles.x + Time.deltaTime * _mouseY * _rotationSpeed * 3;
        if (rotY > 180)
            rotY -= 360;
        rotY = Mathf.Clamp(rotY, -25, 15);
        _CameraAxis.localEulerAngles = new Vector3(rotY, 0, 0);

        _movePlayer = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            _movePlayer += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _movePlayer -= transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _movePlayer += transform.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _movePlayer -= transform.right;
        }
        if (Input.GetKeyDown(KeyCode.Space) && _playerCollider.isGrounded)
        {
            _fallVelocity = -jumpForce;
        }
    }
    private void FixedUpdate()
    {
        _playerCollider.Move(_movePlayer * _speedMove * Time.fixedDeltaTime);
        _fallVelocity += gravity * Time.fixedDeltaTime;
        _playerCollider.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);
        if (_playerCollider.isGrounded)
        {
            _fallVelocity = 0;
        }
    }
}
