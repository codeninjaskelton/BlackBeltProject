using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class LevelEditor
{
    //
    public string levelName;
    public List<EditorObject.Data> editorObjects;
    public float boundarySize;
    public bool isPlayable;
}
