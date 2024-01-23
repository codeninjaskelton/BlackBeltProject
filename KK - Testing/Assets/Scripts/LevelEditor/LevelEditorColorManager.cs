using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditorColorManager : MonoBehaviour
{
    public LevelEditorManager levelEditorManager;
    public LevelEditorInstantiate levelEditorInstantiate;
    
    public Material rock2;
    public Material hobjectMaterial;
    
    public IEnumerator Switch2Rock2(GameObject hobject, int it)
    {
        yield return new WaitForEndOfFrame();
        if (hobject.GetComponent<MeshRenderer>() != null)
        {
            Material hobMaterial = hobject.GetComponent<MeshRenderer>().material;
            hobjectMaterial = hobMaterial;
            Color color = hobMaterial.color;
            hobject.GetComponent<MeshRenderer>().material = rock2;
            hobject.GetComponent<MeshRenderer>().material.color = color;
            while (levelEditorManager.it == it)
            {
                if (hobject == null)
                {
                    yield break;
                }
                if (levelEditorInstantiate.canPlace)
                {
                    hobject.GetComponent<MeshRenderer>().material = hobjectMaterial;
                }
                yield return new WaitForEndOfFrame();
            }
            hobject.GetComponent<MeshRenderer>().material = hobjectMaterial;
        }
        
    }
}
