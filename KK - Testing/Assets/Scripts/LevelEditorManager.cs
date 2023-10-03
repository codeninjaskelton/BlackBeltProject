using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEditorManager : MonoBehaviour
{
    public LevelEditorInstantiate levelEditorInstantiate;
    public LevelEditorColorManager levelEditorColorManager;

    public GameObject hobject;
    public LayerMask layermaskname;

    public InputField transX;
    public InputField transY;
    public InputField rotZ;

    public Vector3 mouseStart;

    public int it;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (!levelEditorInstantiate.canPlace)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && levelEditorInstantiate.isInBoundaries)
            {
                hobject = null;
                it++;
                RaycastHit hit;
                if (Physics.Raycast(new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -10), Vector3.forward, out hit, Mathf.Infinity, layermaskname))
                {
                    hobject = hit.transform.gameObject;
                    transX.text = hobject.transform.position.x.ToString();
                    transY.text = hobject.transform.position.y.ToString();
                    rotZ.text = hobject.transform.rotation.eulerAngles.z.ToString();
                    StartCoroutine(levelEditorColorManager.Switch2Rock2(hobject, it));
                    mouseStart = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - hobject.transform.position.x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y - hobject.transform.position.y, 0);
                    StartCoroutine(MouseHold());
                }

            }

            if (Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.Delete))
            {
                if (levelEditorInstantiate.isInBoundaries)
                {
                    List<GameObject> placed = levelEditorInstantiate.placed;
                    if (placed.Contains(hobject))
                    {
                        placed.Remove(hobject);
                        Destroy(hobject);
                    }
                }
            }

            if (hobject)
            {
                string X = transX.text;
                string Y = transY.text;
                string Z = rotZ.text;

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
                    hobject.transform.rotation = Quaternion.Euler(hobject.transform.position.x, hobject.transform.position.y, retZ);
                }
                if (rotZ.text == "")
                {
                    hobject.transform.rotation = Quaternion.Euler(0 ,0 ,0);
                }
            }
            

        }

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
