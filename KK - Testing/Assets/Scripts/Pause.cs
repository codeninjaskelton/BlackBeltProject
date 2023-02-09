using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool isPaused = false;
    public CinemachineZoom cinemachineZoom;
    public float time;

    private void Start()
    {
        cinemachineZoom = GameObject.Find("GameManager").GetComponent<CinemachineZoom>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(ControlScript.Pause))
        {
            PauseGame();
        }
        if (!isPaused)
        {
            Time.timeScale = time;
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
