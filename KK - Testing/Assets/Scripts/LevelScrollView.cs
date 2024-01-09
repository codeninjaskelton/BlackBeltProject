using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelScrollView : MonoBehaviour
{
    public List<string> allLevels = new List<string>();
    public GameObject levelNameButton;
    public GameObject content;
    public string levelData;
    public DirectoryInfo d;
    public static string levelLoadName;

    //public Text p;

    private void Start()
    {
        //p.text = Application.persistentDataPath;
        if (Directory.Exists(Application.persistentDataPath + "/LevelData/"))
        {
            levelData = Application.persistentDataPath + "/LevelData/";
            d = new DirectoryInfo(levelData);

            foreach (var file in d.GetFiles("*.json"))
            {
                Debug.Log("json " + file.FullName);
                //levelData = levelData.Replace("/", "\\");
                string nameOnly = file.ToString();
                nameOnly = nameOnly.Replace(levelData, "");
                nameOnly = nameOnly.Replace(".json", "");
                allLevels.Add(nameOnly);
                GameObject newLevelName = Instantiate(levelNameButton, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0), content.transform);
                newLevelName.SetActive(true);
                GameObject Child0 = newLevelName.transform.GetChild(0).gameObject;
                Child0.GetComponent<Text>().text = nameOnly;
                newLevelName.name = nameOnly;
                //if ()
                //{
                //    newLevelName.GetComponent<Text>().color = Color.green;
                //}
                //else
                //{
                //    newLevelName.GetComponent<Text>().color = Color.red;
                //}

            }
            
            
        }
    }

    public void InstantiateLevelName()
    {
        string buttonClicked = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(buttonClicked);
        string file = levelData + buttonClicked + ".json";
        levelLoadName = file;
        SceneManager.LoadScene("TestingLoad");
    }
}
