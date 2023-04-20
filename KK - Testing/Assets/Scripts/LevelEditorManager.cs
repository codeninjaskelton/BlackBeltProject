using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEditorManager : MonoBehaviour
{
    public LevelEditorInstantiate levelEditorInstantiate;
    public GameObject hobject;
    public LayerMask layermaskname;

    public InputField transX;
    public InputField transY;

    public Vector3 mouseStart;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !levelEditorInstantiate.canPlace)
        {
            hobject = null;
            RaycastHit hit;
            if (Physics.Raycast(new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -10), Vector3.forward, out hit, Mathf.Infinity, layermaskname))
            {
                hobject = hit.transform.gameObject;
                mouseStart = new Vector3(Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), new Vector2(hobject.transform.position.x, hobject.transform.position.y)), 0);
                StartCoroutine(MouseHold());
                StopAllCoroutines();
            }
            
        }
        //if (hobject && Input.GetKey(KeyCode.Mouse0))
        {
            //hobject.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0) + mouseStart;
        }
        
        if (levelEditorInstantiate.canPlace)
        {

        }
    }

    public IEnumerator MouseHold()
    {
        Debug.Log("once");
        yield return new WaitForSeconds(0.1f);
        
        while (Input.GetKey(KeyCode.Mouse0))
        {
            hobject.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0) + mouseStart;
        }
    }
}
