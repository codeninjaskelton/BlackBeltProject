using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

/// <summary>
/// Scroll through user made levels
/// </summary>
public class LevelScrollView : MonoBehaviour
{
    public List<string> allLevels = new List<string>();
    public GameObject levelNameButton;
    public GameObject content;
    public string levelData;
    public DirectoryInfo d;
    public static string levelLoadName;

    private void Start()
    {
        if (Directory.Exists(Application.persistentDataPath + "/LevelData/"))
        {
            levelData = Application.persistentDataPath + "/LevelData/";
            d = new DirectoryInfo(levelData);

            foreach (var file in d.GetFiles("*.json"))
            {
                string json = File.ReadAllText(file.ToString());
                LevelEditor level = JsonUtility.FromJson<LevelEditor>(json);

                Debug.Log(json);
                string nameOnly = level.levelName;
                allLevels.Add(nameOnly);
                GameObject newLevelName = Instantiate(levelNameButton, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0), content.transform);
                newLevelName.SetActive(true);
                GameObject Child0 = newLevelName.transform.GetChild(0).gameObject;
                Child0.GetComponent<Text>().text = nameOnly;
                newLevelName.name = nameOnly;
                

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
