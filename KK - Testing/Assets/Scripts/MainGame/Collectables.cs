using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public List<GameObject> collectables = new List<GameObject>();
    public GameObject portal;
    public int collectableNumber;

    private void Start()
    {
        if (GameObject.Find("Portal"))
        {
            portal = GameObject.Find("Portal");
        }
    }

    public void Begin()
    {
        if (portal)
        {
            portal.SetActive(false);
        }
        
        for (var i = collectables.Count; i > 1; i--)
        {
            collectables[i - 1].SetActive(false);
        }
    }

    public GameObject GetPortal()
    {
        return portal;
    }
}
