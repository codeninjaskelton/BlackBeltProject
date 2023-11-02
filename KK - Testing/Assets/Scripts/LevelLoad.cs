using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LevelLoad : MonoBehaviour
{
    private LevelEditor level;
    public GameObject[] editorItems;

    public GameObject gameManager;

    private void Awake()
    {
        PlayerPrefs.SetInt("isTimed", 0);
        CreateEditor();
        LoadLevel();
    }

    LevelEditor CreateEditor()
    {
        level = new LevelEditor();
        level.editorObjects = new List<EditorObject.Data>();
        return level;
        
    }

    public void LoadLevel()
    {
        EditorObject[] foundObjects = FindObjectsOfType<EditorObject>();
        foreach (EditorObject obj in foundObjects)
        {
            Destroy(obj.gameObject);
        }

        string json = File.ReadAllText(LevelScrollView.levelLoadName);
        level = JsonUtility.FromJson<LevelEditor>(json);
        CreateFromFile();
    }

    public void CreateFromFile()
    {
        Debug.Log("load");
        FindObjectOfType<Boundaries>().boundaryScale = level.boundarySize;
        //List<GameObject> placed = new List<GameObject>();
        for (int i = 0; i < level.editorObjects.Count; i++)
        {
            GameObject pobject;
            switch (level.editorObjects[i].objectType)
            {
                case EditorObject.ObjectType.Block:
                    pobject = Instantiate(editorItems[0], level.editorObjects[i].pos, level.editorObjects[i].rot);
                    //placed.Add(pobject);
                    break;
                case EditorObject.ObjectType.Star:
                    pobject = Instantiate(editorItems[1], level.editorObjects[i].pos, level.editorObjects[i].rot);
                    gameManager.GetComponent<Collectables>().collectables.Add(pobject);
                    Debug.Log("Star");
                    //placed.Add(pobject);
                    break;
                case EditorObject.ObjectType.Bean:
                
                    pobject = Instantiate(editorItems[2], level.editorObjects[i].pos, level.editorObjects[i].rot);
                    gameManager.GetComponent<UI>().bean = pobject;
                    gameManager.GetComponent<LevelComponents>().player = pobject;
                    gameManager.GetComponent<CinemachineZoom>().bean = pobject;
                    //placed.Add(pobject);
                    break;
                case EditorObject.ObjectType.Portal:
                    pobject = Instantiate(editorItems[3], level.editorObjects[i].pos, level.editorObjects[i].rot);
                    gameManager.GetComponent<CinemachineZoom>().portal = pobject;
                    gameManager.GetComponent<Collectables>().portal = pobject;
                    pobject.GetComponent<Portal>().nextScene = "StartScreen";
                    Debug.Log("portal");
                    //placed.Add(pobject);
                    break;
                case EditorObject.ObjectType.Wind:
                    pobject = Instantiate(editorItems[4], level.editorObjects[i].pos, level.editorObjects[i].rot);
                    //placed.Add(pobject);
                    break;
                case EditorObject.ObjectType.Enemy:
                    pobject = Instantiate(editorItems[5], level.editorObjects[i].pos, level.editorObjects[i].rot);
                    //placed.Add(pobject);
                    break;
                default:
                    break;
            }
            
        }

    }
}
