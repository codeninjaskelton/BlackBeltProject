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

    public Vector3 mouseStart;

    public int it;
    
    private void Start()
    {
        
    }

    private void Update()
    {
        if (!levelEditorInstantiate.canPlace)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                hobject = null;
                it++;
                RaycastHit hit;
                if (Physics.Raycast(new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -10), Vector3.forward, out hit, Mathf.Infinity, layermaskname))
                {
                    hobject = hit.transform.gameObject;
                    StartCoroutine(levelEditorColorManager.Switch2Rock2(hobject, it));
                    mouseStart = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - hobject.transform.position.x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y - hobject.transform.position.y, 0);
                    StartCoroutine(MouseHold());
                }

            }

            if (Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.Delete))
            {
                List<GameObject> placed = levelEditorInstantiate.placed;
                if (placed.Count > 0)
                {
                    Destroy(placed[placed.Count - 1]);
                    placed.RemoveAt(placed.Count - 1);
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
