using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool isPaused = false;
    public CinemachineZoom cinemachineZoom;

    private void Start()
    {
        cinemachineZoom = GameObject.Find("GameManager").GetComponent<CinemachineZoom>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
    }

    void PauseGame()
    {
        if (isPaused == false)
        {
            cinemachineZoom.bean.GetComponent<Rigidbody>().isKinematic = false;
            

        }
        else
        {
            cinemachineZoom.bean.GetComponent<Rigidbody>().isKinematic = true;
        }
        
    }
}
