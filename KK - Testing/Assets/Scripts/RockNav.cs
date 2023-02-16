using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockNav : MonoBehaviour
{
    private GameObject player;
    public float speed;

    private void Start()
    {
        player = GameObject.Find("Bean");
    }

    private void Update()
    {
        gameObject.GetComponent<Rigidbody>().AddForce((player.transform.position - transform.position).normalized * speed * 0.1f);
        if (gameObject.GetComponent<Rigidbody>().velocity.magnitude > speed)
        {
            gameObject.GetComponent<Rigidbody>().velocity = gameObject.GetComponent<Rigidbody>().velocity.normalized * speed;
        }
    }
}
