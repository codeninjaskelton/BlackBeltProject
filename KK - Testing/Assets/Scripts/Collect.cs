using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    private GameObject portal;

    private void Start()
    {
        portal = GameObject.FindGameObjectWithTag("Portal");
        portal.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            portal.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
