using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    public GameObject controls;
    public GameObject main;
    public GameObject settings;
    public InputField LevelSelect;
    public Colour colour;

    private void Start()
    {
        CheckBlank();
        controls.SetActive(false);
        main.SetActive(true);
        settings.SetActive(false);
        GameObject.Find("TimeText").GetComponent<Text>().text = PlayerPrefs.GetFloat("time").ToString();
        
        
    }

    public void ToggleControls()
    {
        Toggle(controls, main);
    }

    public void ToggleSettings()
    {
        Toggle(settings, main);
    }

    public void Toggle(GameObject bject1, GameObject bject2)
    {
        int toggle;
        if (bject1.activeInHierarchy == true)
        {
            toggle = 1;
        }
        else
        {
            toggle = 0;
        }

        if (toggle == 1)
        {
            bject1.SetActive(false);
            bject2.SetActive(true);
        }
        if (toggle == 0)
        {
            bject1.SetActive(true);
            bject2.SetActive(false);
        }
    }
    
    public void StartButton()
    {
        PlayerPrefs.DeleteKey("time");
        int ret = 0;
        if (int.TryParse(LevelSelect.text, out ret))
        {
            if (ret <= 0 || ret > SceneManager.sceneCountInBuildSettings - 2)
            {
                PlayerPrefs.SetInt("isTimed", 1);
                SceneManager.LoadScene(2);
            }
            else
            {
                PlayerPrefs.SetInt("isTimed", 0);
                SceneManager.LoadScene(ret + 1);
            }
        }
        else
        {
            PlayerPrefs.SetInt("isTimed", 1);
            SceneManager.LoadScene(2);
        }
    }

    public void CheckBlank()
    {
        if (LevelSelect.text == "")
        {
            LevelSelect.text = "Level Number...";
        }
    }
}
