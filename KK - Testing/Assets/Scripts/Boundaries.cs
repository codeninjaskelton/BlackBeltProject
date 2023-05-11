using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    [Header("Boundaries")]
    public GameObject boundary;
    public GameObject ground;
    public GameObject ceiling;
    public GameObject leftWall;
    public GameObject rightWall;
    public float[] boundaries;
    public Vector3[] originalPos;
    public Vector3[] originalScale;

    private void Start()
    {
        boundary = GameObject.Find("Boundary");
        ground = boundary.transform.GetChild(0).gameObject;
        ceiling = boundary.transform.GetChild(1).gameObject;
        leftWall = boundary.transform.GetChild(2).gameObject;
        rightWall = boundary.transform.GetChild(3).gameObject;

        originalPos[0] = ground.transform.position;
        originalPos[1] = ceiling.transform.position;
        originalPos[2] = leftWall.transform.position;
        originalPos[3] = rightWall.transform.position;

        originalScale[0] = ;

        boundaries[0] = ground.transform.position.y;
        boundaries[1] = ceiling.transform.position.y;
        boundaries[2] = leftWall.transform.position.x;
        boundaries[3] = rightWall.transform.position.x;
    }

    void ChangeBoundaries(float scale)
    {
        ground.transform.position = originalPos[0] * scale;
        ceiling.transform.position = originalPos[1] * scale;
        leftWall.transform.position = originalPos[2] * scale;
        rightWall.transform.position = originalPos[3] * scale;

    }
}
