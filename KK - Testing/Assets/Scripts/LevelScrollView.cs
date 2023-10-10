using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class LevelScrollView : MonoBehaviour
{
    public List<string> allLevels = new List<string>();
    public GameObject levelNameButton;
    public GameObject content;

    private void Start()
    {
        content = GameObject.Find("Content");
        
        if (Directory.Exists(Application.persistentDataPath))
        {
            string levelData = Application.dataPath + "/levelData/";
            DirectoryInfo d = new DirectoryInfo(levelData);

            Debug.Log("Exists");
            foreach (var file in d.GetFiles("*.json"))
            {
                levelData = levelData.Replace("/", "\\");
                string nameOnly = file.ToString();
                nameOnly = nameOnly.Replace(levelData, "");
                nameOnly = nameOnly.Replace(".json", "");
                allLevels.Add(nameOnly);
                GameObject newLevelName = Instantiate(levelNameButton, content.transform);
                newLevelName.SetActive(true);
                GameObject Child0 = newLevelName.transform.GetChild(0).gameObject;
                Child0.GetComponent<Text>().text = nameOnly;
                
            }
            
        }
    }

    public void InstantiateLevelName(GameObject Button)
    {
        
    }
}
