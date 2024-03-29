using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// Load user made levels
/// </summary>
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
        for (int i = 0; i < level.editorObjects.Count; i++)
        {
            GameObject pobject;
            switch (level.editorObjects[i].objectType)
            {
                case EditorObject.ObjectType.Block:
                    pobject = Instantiate(editorItems[0], level.editorObjects[i].pos, level.editorObjects[i].rot);
                    break;
                case EditorObject.ObjectType.Star:
                    pobject = Instantiate(editorItems[1], level.editorObjects[i].pos, level.editorObjects[i].rot);
                    gameManager.GetComponent<Collectables>().collectables.Add(pobject);
                    Debug.Log("Star");
                    break;
                case EditorObject.ObjectType.Bean:
                
                    pobject = Instantiate(editorItems[2], level.editorObjects[i].pos, level.editorObjects[i].rot);
                    gameManager.GetComponent<UI>().bean = pobject;
                    gameManager.GetComponent<LevelComponents>().player = pobject;
                    gameManager.GetComponent<CinemachineZoom>().bean = pobject;
                    gameManager.GetComponent<Pause>().bean = pobject;
                    GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                    foreach (GameObject enemy in enemies)
                    {
                        enemy.GetComponent<RockNav>().player = pobject;
                    }
                    break;
                case EditorObject.ObjectType.Portal:
                    pobject = Instantiate(editorItems[3], level.editorObjects[i].pos, level.editorObjects[i].rot);
                    gameManager.GetComponent<CinemachineZoom>().portal = pobject;
                    gameManager.GetComponent<Collectables>().portal = pobject;
                    pobject.GetComponent<Portal>().nextScene = "LStartScreen";
                    Debug.Log("portal");
                    break;
                case EditorObject.ObjectType.Wind:
                    pobject = Instantiate(editorItems[4], level.editorObjects[i].pos, level.editorObjects[i].rot);
                    break;
                case EditorObject.ObjectType.Enemy:
                    pobject = Instantiate(editorItems[5], level.editorObjects[i].pos, level.editorObjects[i].rot);
                    pobject.GetComponent<RockNav>().player = GameObject.FindGameObjectWithTag("Player");
                    pobject.GetComponent<RockNav>().rock = pobject.transform.GetChild(0).gameObject;
                    break;
                default:
                    break;
            }
            
        }

    }
}
