using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0.1f, 0, 0), ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-0.1f, 0, 0), ForceMode.Impulse);
        }
    }
}
