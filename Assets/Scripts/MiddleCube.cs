using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleCube : MonoBehaviour
{
    public Transform PointA;
    public Transform PointB;


    void Update()
    {
        var diraction = (PointA.position + PointB.position)/2;
        var middle = Vector3.Lerp(transform.position ,diraction, Time.deltaTime*3);
        transform.position = middle;
    }
}
