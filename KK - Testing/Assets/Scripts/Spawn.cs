using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public int[] spawnObjects;
    public GameObject[] bject;
    public Vector3[] position;
    public Quaternion[] rotation;
    public bool[] hasLifeSpan;
    public float[] lifeSpan;
    public float[] waitSeconds;
    
    public void Start()
    {
       
        for (var i = spawnObjects.Length; i > 0; i--)
        {

            StartCoroutine(WaitSeconds(i));

        }

    }

    void SpawnObject(GameObject bject, Vector3 position, Quaternion rotation, bool hasLifeSpan, float lifeSpan)
    {
        var spawnObject = Instantiate(bject, position, rotation);
        if (hasLifeSpan)
        {
            Destroy(spawnObject, lifeSpan);
        }
    }

    IEnumerator WaitSeconds(int number)
    {
        yield return new WaitForSeconds(waitSeconds[number]);
        //SpawnObject();
    }
}
