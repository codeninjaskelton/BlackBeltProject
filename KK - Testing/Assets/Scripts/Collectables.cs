using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public GameObject[] collectables;

    private void Start()
    {
        for (var i = collectables.Length; i > 1; i--)
        {
            collectables[i - 1].SetActive(false);
        }
    }
}
