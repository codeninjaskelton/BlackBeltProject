using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    private GameObject portal;
    private Collectables collectables;
    private bool lastCollectable = false;
    public GameObject collectSound;
    public UI ui;

    private void Start()
    {
        collectables = GameObject.Find("GameManager").GetComponent<Collectables>();
        collectables.collectableNumber = collectables.collectables.Length;
        portal = collectables.GetPortal();
        ui = GameObject.Find("GameManager").GetComponent<UI>();
        if (gameObject == collectables.collectables[collectables.collectables.Length - 1])
        {
            lastCollectable = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject c = Instantiate(collectSound);
            c.GetComponent<AudioSource>().time = 0.10f;
            StopCoroutine(ui.Rock());
            ui.StartRock();
            if (portal.activeInHierarchy == false)
            {
                gameObject.SetActive(false);
                if (lastCollectable == false)
                {
                    collectables.collectables[collectables.collectables.Length - collectables.collectableNumber].SetActive(true);
                    collectables.collectableNumber -= 1;
                }
            }

            if (lastCollectable == true)
            {
                PortalOn();
            }
            
        }
    }
    
    void PortalOn()
    {
        portal.SetActive(true);
        collectables.collectables = new GameObject[0];
    }
}