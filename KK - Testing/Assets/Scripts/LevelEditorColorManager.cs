using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditorColorManager : MonoBehaviour
{
    public LevelEditorManager levelEditorManager;
    
    public Material rock2;
    public Material hobjectMaterial;
    //old

    public IEnumerator Switch2Rock2(GameObject hobject)
    {
        Material hobMaterial = hobject.GetComponent<MeshRenderer>().material;
        hobjectMaterial = hobMaterial;
        hobMaterial = rock2;
        hobMaterial.color = hobjectMaterial.color;
        hobject.GetComponent<MeshRenderer>().material = hobMaterial;
        while (levelEditorManager.hobject == hobject)
        {
            yield return new WaitForEndOfFrame();
        }
        hobject.GetComponent<MeshRenderer>().material = hobjectMaterial;
       // hobjectMaterial.color = Color.white;
    }
}
