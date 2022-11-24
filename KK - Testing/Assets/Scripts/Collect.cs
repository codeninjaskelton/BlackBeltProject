using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    private GameObject portal;
    private Collectables collectables;
    private int collectableNumber;

    private void Start()
    {
        portal = GameObject.Find("Portal");
        Debug.Log(portal);
        portal.SetActive(false);
        collectables = GameObject.Find("GameManager").GetComponent<Collectables>();
        collectableNumber = collectables.collectables.Length;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collectableNumber == 0)
            {
                portal.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
                collectables.collectables[collectables.collectables.Length - collectableNumber].SetActive(true);
                collectableNumber -= 1;
            }
        }
    }
}
