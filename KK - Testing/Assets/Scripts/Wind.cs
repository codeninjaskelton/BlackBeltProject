using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    private GameObject player;
    private GameObject top;
    private GameObject bottom;
    [SerializeField] private bool isColliding = false;
    public float forceApplied = 1000;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    private void OnTriggerEnter(Collider other)
    {
        isColliding = true;
        if (other.gameObject.tag == "Player" )
        {
            player.GetComponent<Rigidbody>().AddForce(transform.forward * forceApplied);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isColliding = false;
    }
}
