using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using System;
public class UI : MonoBehaviour
{
    public Text levelText;
    public string levelNumber;
    private string levelType;
    public GameObject mainMenuButton;
    public Pause pause;

    private void Start()
    {
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
        pause = GameObject.Find("GameManager").GetComponent<Pause>();
        mainMenuButton = GameObject.Find("MainMenuButton");
        levelNumber = SceneManager.GetActiveScene().name;
        LevelNumber();
    }

    private void Update()
    {
        if (pause.isPaused)
        {
            mainMenuButton.SetActive(true);
        }
        else
        {
            mainMenuButton.SetActive(false);
        }
    }

    public void LevelNumber()
    {
        string lvl = "";
        string tst = "";
        if (levelNumber.Length >= 6)
        {
            for (int i = 0; i < 5; i++)
            {
                lvl += levelNumber[i];
            }
        }
        if (levelNumber.Length >= 8)
        {
            for (int i = 0; i < 7; i++)
            {
                tst += levelNumber[i];
            }
        }
        
        if (lvl == "Level")
        {
            levelType = "Level";
        }
        else if (tst == "Testing")
        {
            levelType = "Testing";
        }
        if (levelType == "Testing" && levelNumber.Length != 7)
        {
            if (levelNumber.Length > levelType.Length)
            {
                string levelName = "";
                levelText.text = levelName;
                for (int i = 0; i < levelType.Length; i++)
                {
                        levelName += levelNumber[i];
                }
                if (levelName == levelType)
                {
                    string level = "";
                    for (int i = levelType.Length; i < levelNumber.Length; i++)
                    {
                        level += levelNumber[i];
                    }
                    int ret = 0;
                    if (int.TryParse(level, out ret))
                    {
                        if (ret < 10)
                        {
                            levelText.text += 0;
                        }
                    }
                    levelText.text += level;
                }
            }
        }
        
    }
}