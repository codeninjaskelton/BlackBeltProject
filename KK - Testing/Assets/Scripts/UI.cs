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
    public string levelType;

    private void Start()
    {
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
        levelNumber = SceneManager.GetActiveScene().name;
        LevelNumber();
    }

    public void LevelNumber()
    {
        
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
                levelText.text = level;
            }
        }
        
       // char[] newi = levelText.text.ToCharArray(0, levelText.text.Length);
        
    }
}