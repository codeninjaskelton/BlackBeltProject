using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public static LevelEditor level;
    public InputField levelNameSave;
    public InputField levelNameLoad;
    public GameObject[] editorItems;


    void Start()
    {
        CreateEditor();
    }

    LevelEditor CreateEditor()
    {
        level = new LevelEditor();
        level.editorObjects = new List<EditorObject.Data>();
        return level;
    }

    public void SaveLevel()
    {
        CreateEditor();
        bool bean = false;
        bool portal = false;

        EditorObject[] foundObjects = FindObjectsOfType<EditorObject>();
        foreach (EditorObject obj in foundObjects)
        {
            level.editorObjects.Add(obj.data);
        }

        Debug.Log(foundObjects.Length);

        for (int i = 0; i < foundObjects.Length; i++)
        {
            if (foundObjects[i] == editorItems[2])
            {
                bean = true;
            }
            if (foundObjects[i] == editorItems[3])
            {
                portal = true;
            }
        }
        if (bean && portal)
        {
            level.isPlayable = true;
        }

        level.boundarySize = FindObjectOfType<Boundaries>().boundaryScale;

        string json = JsonUtility.ToJson(level);
        string folder = Application.dataPath + "/LevelData/";
        string levelFile = "";

        if (levelNameSave.text == "")
        {
            levelFile = "new_level.json";
        }
        else
        {
            levelFile = levelNameSave.text + ".json";
        }

        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }

        string path = Path.Combine(folder, levelFile);

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        File.WriteAllText(path, json);
    }

    public void LoadLevel()
    {
        string folder = Application.dataPath + "/LevelData/";
        string levelFile = "";

        if (levelNameLoad.text == "")
        {
            levelFile = "new_level.json";
        }
        else
        {
            levelFile = levelNameLoad.text + ".json";
        }

        string path = Path.Combine(folder, levelFile);

        if (File.Exists(path))
        {
            EditorObject[] foundObjects = FindObjectsOfType<EditorObject>();
            foreach (EditorObject obj in foundObjects)
            {
                Destroy(obj.gameObject);
            }

            string json = File.ReadAllText(path);
            level = JsonUtility.FromJson<LevelEditor>(json);
            CreateFromFile();
        }
        //else
    }

    void CreateFromFile()
    {

        FindObjectOfType<Boundaries>().boundaryScale = level.boundarySize;
        List<GameObject> placed = new List<GameObject>();
        for (int i = 0; i < level.editorObjects.Count; i++)
        {
            switch (level.editorObjects[i].objectType)
            {
                case EditorObject.ObjectType.Block:
                    placed.Add(Instantiate(editorItems[0], level.editorObjects[i].pos, level.editorObjects[i].rot));
                    break;
                case EditorObject.ObjectType.Star:
                    placed.Add(Instantiate(editorItems[1], level.editorObjects[i].pos, level.editorObjects[i].rot));
                    break;
                case EditorObject.ObjectType.Bean:
                    placed.Add(Instantiate(editorItems[2], level.editorObjects[i].pos, level.editorObjects[i].rot));
                    break;
                case EditorObject.ObjectType.Portal:
                    placed.Add(Instantiate(editorItems[3], level.editorObjects[i].pos, level.editorObjects[i].rot));
                    break;
                case EditorObject.ObjectType.Wind:
                    placed.Add(Instantiate(editorItems[4], level.editorObjects[i].pos, level.editorObjects[i].rot));
                    break;
                case EditorObject.ObjectType.Enemy:
                    placed.Add(Instantiate(editorItems[5], level.editorObjects[i].pos, level.editorObjects[i].rot));
                    break;
                default:
                    break;
            }
        }
        FindObjectOfType<LevelEditorInstantiate>().placed = placed;

    }
}
