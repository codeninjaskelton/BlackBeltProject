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
    public GameObject backdrop;
    public List<float> boundaries = new List<float>(4);
    public List<Vector3> originalPos = new List<Vector3>(5);
    public List<Vector3> originalScale = new List<Vector3>(5);
    public float boundaryScale = 1;

    private void Start()
    {
        boundary = GameObject.Find("Boundary");
        ground = boundary.transform.GetChild(0).gameObject;
        ceiling = boundary.transform.GetChild(1).gameObject;
        leftWall = boundary.transform.GetChild(2).gameObject;
        rightWall = boundary.transform.GetChild(3).gameObject;
        backdrop = boundary.transform.GetChild(4).gameObject;

        
        originalPos[0] = ground.transform.position;
        originalPos[1] = ceiling.transform.position;
        originalPos[2] = leftWall.transform.position;
        originalPos[3] = rightWall.transform.position;
        originalPos[4] = backdrop.transform.position;

        originalScale[0] = ground.transform.localScale;
        originalScale[1] = ceiling.transform.localScale;
        originalScale[2] = leftWall.transform.localScale;
        originalScale[3] = rightWall.transform.localScale;
        originalScale[4] = backdrop.transform.localScale;

        UpdateBoundaries();
    }

    private void Update()
    {
        ChangeBoundaries(boundaryScale);
    }

    public void ChangeBoundaries(float scale)
    {
        ground.transform.position = originalPos[0] * scale;
        ceiling.transform.position = originalPos[1] * scale;
        leftWall.transform.position = originalPos[2] * scale;
        rightWall.transform.position = originalPos[3] * scale;
        backdrop.transform.position = originalPos[4] * scale;

        ground.transform.localScale = originalScale[0] * scale;
        ceiling.transform.localScale = originalScale[1] * scale;
        leftWall.transform.localScale = originalScale[2] * scale;
        rightWall.transform.localScale = originalScale[3] * scale;
        backdrop.transform.localScale = originalScale[4] * scale;

        UpdateBoundaries();
    }

    public void UpdateBoundaries()
    {
        boundaries[0] = ground.transform.position.y;
        boundaries[1] = ceiling.transform.position.y;
        boundaries[2] = leftWall.transform.position.x;
        boundaries[3] = rightWall.transform.position.x;
    }
}