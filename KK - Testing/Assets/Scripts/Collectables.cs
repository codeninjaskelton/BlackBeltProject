using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public GameObject[] collectables;
    public GameObject portal;
    public int collectableNumber;

    private void Start()
    {
        portal = GameObject.Find("Portal");
        portal.SetActive(false);
        for (var i = collectables.Length; i > 1; i--)
        {
            collectables[i - 1].SetActive(false);
        }
    }

    public GameObject GetPortal()
    {
        return portal;
    }
}
