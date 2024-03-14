using UnityEngine;
using UnityEngine.UI;

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
    private Animator _animator;
    


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _playerCollider = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _movePlayer = Vector3.zero;
    }

    void Update()
    {
        var runDiraction = 0;
        _mouseX = Input.GetAxis("Mouse X");
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + Time.deltaTime * _mouseX * _rotationSpeed, 0);
        _movePlayer = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            _movePlayer += transform.forward;
            runDiraction = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _movePlayer -= transform.forward;
            runDiraction = 2;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _movePlayer += transform.right;
            runDiraction = 3;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _movePlayer -= transform.right;
            runDiraction = 4;
        }
        if (Input.GetKeyDown(KeyCode.Space) && _playerCollider.isGrounded)
        {
            _fallVelocity = -jumpForce;
            runDiraction = 5;
        }
        _animator.SetInteger("run diraction", runDiraction);
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
