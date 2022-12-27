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

    private void Start()
    {
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
        levelNumber = SceneManager.GetActiveScene().name;
        LevelNumber();
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

        if (levelNumber.Length > levelType.Length)
        {
            string levelName = "";
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
                levelText.text = levelType;
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