using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    private GameObject player;
    private GameObject top;
    private GameObject bottom;
    [SerializeField] private bool isColliding = false;
    public float forceApplied;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        top = gameObject.transform.GetChild(1).gameObject;
        bottom = gameObject.transform.GetChild(2).gameObject;
    }

    private void Update()
    {
        var sh = transform.GetChild(0).GetComponent<ParticleSystem>().shape;
        var em = transform.GetChild(0).GetComponent<ParticleSystem>().emission;
        var ma = transform.GetChild(0).GetComponent<ParticleSystem>().main;
        sh.scale = new Vector3(transform.localScale.x * 5, transform.localScale.y * 1, transform.localScale.z * 1);
        em.rateOverTime = forceApplied * 10;
        ma.startLifetime = transform.localScale.y * 2 / forceApplied;
        ma.startSpeed = forceApplied * 5;

        Vector3 dif = top.transform.position - bottom.transform.position;
        if (PlayerMove.pause == false)
        {
            if (isColliding)
            {
                player.GetComponent<Rigidbody>().AddForce(dif * forceApplied);
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" )
        {
            isColliding = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        isColliding = false;
    }
}
