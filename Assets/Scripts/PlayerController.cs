using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _mouseX;
    private float _mouseY;
    [SerializeField ]private float _rotationSpeed = 15f;
    [SerializeField] private Transform _CameraAxis;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        _mouseY = Input.GetAxis("Mouse Y");
        _mouseX = Input.GetAxis("Mouse X");
        //float rotationYMouse = Mathf.Clamp(transform.localEulerAngles.x, -15f, 65f);
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y  + Time.deltaTime * _mouseX * _rotationSpeed, 0);
        float rotY = _CameraAxis.localEulerAngles.x + Time.deltaTime * _mouseY * _rotationSpeed;
        if (rotY > 180)
            rotY -= 360;
        rotY = Mathf.Clamp(rotY, -25, 15);
        _CameraAxis.localEulerAngles = new Vector3(rotY, 0, 0);

    }
}
