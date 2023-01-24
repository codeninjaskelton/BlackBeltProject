using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComponents : MonoBehaviour
{
    public string[] levelComponents;
    public GameObject player;
    public Spawn spawnScript;

    private void Start()
    {
        player = GameObject.Find("Bean");
        spawnScript = GameObject.Find("GameManager").GetComponent<Spawn>();

        Physics.gravity = new Vector3(0, -9.81f);
        for (var i = 0; i < levelComponents.Length; i++)
        {
            if (levelComponents[i] == "moongravity")
            {
                Physics.gravity = new Vector3(0, -1.62f);
            }
            if (levelComponents[i] == "sungravity")
            {
                Physics.gravity = new Vector3(0, -274);
            }
            
        }
    }

    private void Update()
    {
        

        for (var i = 0; i < levelComponents.Length; i++)
        {
            if (levelComponents[i] == "moongravity")
            {
                Physics.gravity = new Vector3(0, -1.62f);
            }
            if (levelComponents[i] == "sungravity")
            {
                Physics.gravity = new Vector3(0, -274);
            }
            if (levelComponents[i] == "clone")
            {
                if (Input.GetKeyDown(KeyCode.C))
                {
                    spawnScript.SpawnPlayer(player, player.transform.position, player.transform.rotation);
                }
            }
        }
    }
}
