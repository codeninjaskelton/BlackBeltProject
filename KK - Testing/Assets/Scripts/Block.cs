using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [Header("Rotate")]
    public float rotateX;
    public float rotateY;
    public float rotateZ;

    [Header("Translate")]
    [Header("X")]
    public float TranslateXStart;
    public float TranslateXEnd;
    [Header("Y")]
    public float TranslateYStart;
    public float TranslateYEnd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(rotateX / 100, rotateY / 100, rotateZ / 100));
    }
}
