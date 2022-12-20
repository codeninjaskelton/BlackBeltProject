using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    public GameObject controls;
    public GameObject notControls;
    public InputField LevelSelect;

    private void Start()
    {
        CheckBlank();
        controls.SetActive(false);
        notControls.SetActive(true);
        GameObject.Find("TimeText").GetComponent<Text>().text = PlayerPrefs.GetFloat("time").ToString();
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
