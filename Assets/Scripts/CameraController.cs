using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private float _rotationSpeed = 15f;
    [SerializeField] private Transform _CameraAxis;
    //[SerializeField] private Transform _player;
    private float _mouseY;

    void Update()
    {

        RotationCamera();   
    }
    public void RotationCamera()
    {
        _mouseY = Input.GetAxis("Mouse Y");
        float rotY = _CameraAxis.localEulerAngles.x + Time.deltaTime * -_mouseY * _rotationSpeed * 3;
        if (rotY > 180)
            rotY -= 360;
        rotY = Mathf.Clamp(rotY, -25, 15);
        _CameraAxis.localEulerAngles = new Vector3(rotY, 0, 0);
    }
}
