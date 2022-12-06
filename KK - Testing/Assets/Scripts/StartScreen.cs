using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public GameObject controls;
    public GameObject notControls;

    private void Start()
    {
        controls.SetActive(false);
        notControls.SetActive(true);
    }

    public void ToggleControls()
    {
        int toggle;
        if (controls.activeInHierarchy == true)
        {
            toggle = 1;
        }
        else
        {
            toggle = 0;
        }

        if (toggle == 1)
        {
            controls.SetActive(false);
            notControls.SetActive(true);
        }
        if (toggle == 0)
        {
            controls.SetActive(true);
            notControls.SetActive(false);
        }
    }   
    
    public void StartButton()
    {
        SceneManager.LoadScene("Testing1");
    }
}
