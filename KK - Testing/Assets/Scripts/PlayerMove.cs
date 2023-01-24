using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Particles particles;
    public static bool pause = false;
    // Start is called before the first frame update
    void Start()
    {
        particles = GameObject.Find("GameManager").GetComponent<Particles>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            pause = false;
            if (Input.GetKey(KeyCode.D))
            {
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0.1f, 0, 0), ForceMode.Impulse);
            }
            if (Input.GetKey(KeyCode.A))
            {
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-0.1f, 0, 0), ForceMode.Impulse);
            }
        }
        else
        {
            pause = true;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        particles.PBounce();
    }
}
