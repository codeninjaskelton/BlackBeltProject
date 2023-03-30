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

    private void Start()
    {
        boundary = GameObject.Find("Boundary");
        ground = boundary.transform.GetChild(0).gameObject;
        ceiling = boundary.transform.GetChild(1).gameObject;
        leftWall = boundary.transform.GetChild(2).gameObject;
        rightWall = boundary.transform.GetChild(3).gameObject;

        boundaries[0] = ground.transform.position.y;
        boundaries[1] = ceiling.transform.position.y;
        boundaries[2] = leftWall.transform.position.x;
        boundaries[3] = rightWall.transform.position.x;
    }
}
