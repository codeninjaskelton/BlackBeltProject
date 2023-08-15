using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComponents : MonoBehaviour
{
    public UI ui;
    public Pause pause;
    public string[] levelComponents;
    public GameObject player;
    public Spawn spawnScript;
    public bool moonGravity;
    public float timeSpeed = 1;

    private void Start()
    {
        ui = gameObject.GetComponent<UI>();
        pause = gameObject.GetComponent<Pause>();
        player = GameObject.Find("Bean");
        spawnScript = GameObject.Find("GameManager").GetComponent<Spawn>();
        moonGravity = GameSettings.moon;
        Time.timeScale = 1;
        timeSpeed = 1;

        Physics.gravity = new Vector3(0, -9.81f);
        
        if (moonGravity)
            {
                Physics.gravity = new Vector3(0, -1.62f);
            }
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
        //timeSpeed = Time.timeScale;

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
            if (levelComponents[i] == "enrico")
            {
                if (!pause.isPaused)
                {
                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        Slower();
                        
                    }
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Faster();

                    }  
                    Time.timeScale = timeSpeed;
                }
            }
            
        }
     
    }

    public void Slower()
    {
        if (timeSpeed > 0.2f)
        {
            //float time = timeSpeed;
            timeSpeed -= 0.1f;
            timeSpeed = Mathf.Round(timeSpeed * 10) / 10;
            //timeSpeed = time;
            ui.CallNewMessage(timeSpeed.ToString());
        }

    }

    public void Faster()
    {
        //float time = timeSpeed;
        timeSpeed += 0.1f;
        timeSpeed = Mathf.Round(timeSpeed * 10) / 10;
       // timeSpeed = time;
        ui.CallNewMessage(timeSpeed.ToString());

    }
}
