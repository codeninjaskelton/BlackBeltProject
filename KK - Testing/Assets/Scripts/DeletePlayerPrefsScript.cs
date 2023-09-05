using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
public class DeletePlayerPrefsScript : EditorWindow
{

    [MenuItem("Window/Delete PlayerPrefs (All)")]
    static void DeleteAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

}
#endif