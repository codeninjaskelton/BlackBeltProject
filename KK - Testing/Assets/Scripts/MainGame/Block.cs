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
    public bool canMove;
    public float time;
    public bool moveInSeconds;
    public float translateSpeed;
    public AnimationCurve curve;
    public Vector2 translateStart;
    public Vector2 translateEnd;

    private void Start()
    {
        translateStart = transform.position;
        translateEnd = translateStart + translateEnd;
    }

    void Update()
    {
        
        if (Pause.isPaused == false)
        {
            gameObject.transform.Rotate(new Vector3(rotateX / 100, rotateY / 100, rotateZ / 100));
            if (moveInSeconds == true)
            {
                time += Time.deltaTime;
            }
            else if (moveInSeconds == false)
            {
                time += translateSpeed / 1000;
            }
        
            if (canMove == true)
            {
                gameObject.GetComponent<Rigidbody>().MovePosition(Vector2.Lerp(translateStart, translateEnd, curve.Evaluate(time)));
            }
        }
        
    }
}
