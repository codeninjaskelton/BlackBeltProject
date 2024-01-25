using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanCamera : MonoBehaviour
{
    private float _rotationX = 0;

    void Update()
    {
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
