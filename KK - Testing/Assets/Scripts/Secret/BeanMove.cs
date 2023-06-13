using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanMove : MonoBehaviour
{
    public Rigidbody beanRb;
    public float moveSpeed;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            beanRb.AddForce(transform.forward * moveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            beanRb.AddForce(transform.forward * -moveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            beanRb.AddForce(transform.right * -moveSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            beanRb.AddForce(transform.right * moveSpeed);
        }
        
    }
}
