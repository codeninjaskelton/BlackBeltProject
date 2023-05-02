using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditorColorManager : MonoBehaviour
{
    public LevelEditorManager levelEditorManager;
    
    public Material rock2;
    public Material hobjectMaterial;
    //old
    
    public IEnumerator Switch2Rock2(GameObject hobject, int it)
    {
        Material hobMaterial = hobject.GetComponent<MeshRenderer>().material;
        hobjectMaterial = hobMaterial;
        
        hobject.GetComponent<MeshRenderer>().material = rock2;
        while (levelEditorManager.it == it)
        {
            yield return new WaitForEndOfFrame();
        }
        hobject.GetComponent<MeshRenderer>().material = hobjectMaterial;
    }
}
