using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelEditorManager : MonoBehaviour
{
    public LevelEditorInstantiate levelEditorInstantiate;
    public LevelEditorColorManager levelEditorColorManager;

    public GameObject hobject;
    public LayerMask layermaskname;

    public InputField posX;
    public InputField posY;
    public InputField rotZ;
    public InputField scaleX;
    public InputField scaleY;

    public Vector3 mouseStart;

    public int it;

    public string vX;
    public string vY;
    public string vZ;
    public string vSX;
    public string vSY;

    public bool sceneSelected;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (hobject != null)
        {
            if (posX.text == vX)
            {
                posX.text = hobject.transform.position.x.ToString();
            }
            if (posY.text == vY)
            {
                posY.text = hobject.transform.position.y.ToString();
            }
            if (posX.text == "")
            {
                hobject.transform.position = new Vector3(0, hobject.transform.position.y, hobject.transform.position.z);
            }
            if (posY.text == "")
            {
                hobject.transform.position = new Vector3(hobject.transform.position.x, 0, hobject.transform.position.z);
            }
        }
        
        if (!levelEditorInstantiate.canPlace)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && levelEditorInstantiate.isInBoundaries && sceneSelected)
            {
                hobject = null;
                it++;
                RaycastHit hit;
                if (Physics.Raycast(new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -10), Vector3.forward, out hit, Mathf.Infinity, layermaskname))
                {
                    hobject = hit.transform.gameObject;
                    StartCoroutine(levelEditorColorManager.Switch2Rock2(hobject, it));
                    mouseStart = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - hobject.transform.position.x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y - hobject.transform.position.y, 0);
                    posX.text = hobject.transform.position.x.ToString();
                    posY.text = hobject.transform.position.y.ToString();
                    rotZ.text = hobject.transform.rotation.eulerAngles.z.ToString();
                    scaleX.text = hobject.transform.localScale.x.ToString();
                    scaleY.text = hobject.transform.localScale.y.ToString();
                    StartCoroutine(MouseHold());
                }

            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (levelEditorInstantiate.isInBoundaries)
                {
                    sceneSelected = true;
                }
                else
                {
                    sceneSelected = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.Delete))
            {
                //if (levelEditorInstantiate.isInBoundaries)
                //{
                    if (sceneSelected)
                    {

                    
                        List<GameObject> placed = levelEditorInstantiate.placed;
                        if (placed.Contains(hobject))
                        {
                            placed.Remove(hobject);
                            Destroy(hobject);
                        }
                    }
                //}
            }

            if (hobject)
            {
                string X = posX.text;
                string Y = posY.text;
                string Z = rotZ.text;
                string sX = scaleX.text;
                string sY = scaleY.text;

                if (float.TryParse(X, out float retX))
                {
                    hobject.transform.position = new Vector3(retX, hobject.transform.position.y, hobject.transform.position.z);
                }
                if (float.TryParse(Y, out float retY))
                {
                    hobject.transform.position = new Vector3(hobject.transform.position.x, retY, hobject.transform.position.z);
                }
                if (float.TryParse(Z, out float retZ))
                {
                    hobject.transform.rotation = Quaternion.Euler(hobject.transform.rotation.x, hobject.transform.rotation.y, retZ);
                }
                if (rotZ.text == vZ)
                {
                    if (rotZ.text == "")
                    {
                        hobject.transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                }
                if (scaleX.text == vSX)
                {
                    if (scaleX.text == "")
                    {
                        hobject.transform.localScale = new Vector3(0.1f, hobject.transform.localScale.y, hobject.transform.localScale.z);
                    }
                    else if (float.TryParse(sX, out float retSX))
                    {
                        hobject.transform.localScale = new Vector3(retSX, hobject.transform.localScale.y,hobject.transform.localScale.z);
                    }
                }
                if (scaleX.text == vSY)
                {
                    if (scaleY.text == "")
                    {
                        hobject.transform.localScale = new Vector3(hobject.transform.localScale.x, 0.1f, hobject.transform.localScale.z);
                    }
                    else if (float.TryParse(sY, out float retSY))
                    {
                        hobject.transform.localScale = new Vector3(hobject.transform.localScale.x, retSY, hobject.transform.localScale.z);
                    }
                }
            }
            

        }

        vX = posX.text;
        vY = posY.text;
        vZ = rotZ.text;
        vSX = scaleX.text;
        vSY = scaleY.text;
    }

    public IEnumerator MouseHold()
    {
        yield return new WaitForSeconds(0.1f);

        while (Input.GetKey(KeyCode.Mouse0))
        {
            hobject.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0) - mouseStart;
            yield return null;
        }
    }
}
