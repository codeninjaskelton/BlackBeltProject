using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bean : MonoBehaviour
{
    public Rigidbody beanRb;
    public Camera cam;
    public float moveSpeed;

    private float _rotationX = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
        
        if (Input.GetKey(KeyCode.Mouse1))
        {
            _rotationX -= Input.GetAxis("Mouse Y") * 2;
            _rotationX = Mathf.Clamp(_rotationX, -90, 90);
            float delta = Input.GetAxis("Mouse X") * 2;
            float rotationY = transform.localEulerAngles.y + delta;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        
    }
}
