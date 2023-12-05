using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Particles particles;
    // Start is called before the first frame update
    void Start()
    {
        particles = gameObject.GetComponent<Particles>();
        //Application.targetFrameRate = 100;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.timeScale != 0)
        {
            Pause.isPaused = false;
            if (Input.GetKey(ControlScript.Right))
            {
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(30f, 0, 0), ForceMode.Force);
            }
            if (Input.GetKey(ControlScript.Left))
            {
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-30f, 0, 0), ForceMode.Force);
            }

        }
        else
        {
            Pause.isPaused = true;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(particles.PBounce());
    }
}
