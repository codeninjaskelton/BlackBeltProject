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
            cinemachineZoom.Pause();
            isPaused = true;
        }
        else
        {
            StartCoroutine(cinemachineZoom.PauseZoom(cinemachineZoom.bean, null, null));
            isPaused = false;
        }
        
    }
}
