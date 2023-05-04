using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditorColorManager : MonoBehaviour
{
    public LevelEditorManager levelEditorManager;
    public LevelEditorInstantiate levelEditorInstantiate;
    
    public Material rock2;
    public Material hobjectMaterial;
    //old
    
    public IEnumerator Switch2Rock2(GameObject hobject, int it)
    {
        yield return new WaitForEndOfFrame();
        Material hobMaterial = hobject.GetComponent<MeshRenderer>().material;
        hobjectMaterial = hobMaterial;
        
        hobject.GetComponent<MeshRenderer>().material = rock2;
        while (levelEditorManager.it == it )
        {
            if (levelEditorInstantiate.canPlace)
            {
                hobject.GetComponent<MeshRenderer>().material = hobjectMaterial;
            }
            yield return new WaitForEndOfFrame();
        }
        hobject.GetComponent<MeshRenderer>().material = hobjectMaterial;
    }
}
