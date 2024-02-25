using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEmission : MonoBehaviour
{
    [Range(0f, 1f)]
    public float range;

    private Vector3 posCubeA = Vector3.zero;
    private Vector3 posCubeB = new Vector3(10,0,0);

    private Vector3 scaleCubeA = new Vector3(5,0.1f,5);
    private Vector3 scaleCubeB = new Vector3(10, 1f, 10);

    public Material materialA;
    public Material materialB;
    public Material materialC;
    public MeshRenderer cubeMeshRenderer;



    void Update()
    {
        var positionCube = Vector3.Lerp(posCubeA, posCubeB, range);
        var scale = Vector3.Lerp(scaleCubeA, scaleCubeB, range);
        var materials = Color.Lerp(materialA.color, materialB.color, range);
        transform.position = positionCube;
        transform.localScale = scale;
        cubeMeshRenderer.material.color = materials;
    }
}
