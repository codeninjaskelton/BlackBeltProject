using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [Header("Rotate")]
    public float rotateX;
    public float rotateY;
    public float rotateZ;
    
    [Header("Translate:")]
    [Header("Start")]
    public float translateStartX;
    public float translateStartY;
    [Header("End")]
    public float translateEndX;
    public float translateEndY;

    // Start is called before the first frame update
    void Start()
    {
        TranslateStart();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(rotateX / 100, rotateY / 100, rotateZ / 100));
    }

    void TranslateStart()
    {
        Vector2 StartX = new Vector2(translateStartX, 0);
        Vector2 EndX = new Vector2(translateEndX, 0);
        Vector2 StartY = new Vector2(0, translateStartY);
        Vector2 EndY = new Vector2(0, translateEndY);
        var step = -1 * Time.deltaTime;
        gameObject.transform.position = Vector2.MoveTowards(StartX + StartY,EndX + EndY , step);
    }
}
