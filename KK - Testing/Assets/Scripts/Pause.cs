using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool isPaused;
    public CinemachineZoom cinemachineZoom;
    public float time;
    public GameObject bean;
    public Vector3 beanV;

    private void Start()
    {
        cinemachineZoom = GameObject.Find("GameManager").GetComponent<CinemachineZoom>();
        bean = GameObject.Find("Bean");
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
            cinemachineZoom.CinePause();
            isPaused = true;
            if (bean != null)
            {
                beanV = bean.GetComponent<Rigidbody>().velocity;
                bean.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }

            
        }
        else
        {
            StartCoroutine(cinemachineZoom.PauseZoom(cinemachineZoom.bean, null, null));
            isPaused = false;
            if (bean != null)
            {
                bean.GetComponent<Rigidbody>().velocity = beanV;
            }

        }
    }
}
