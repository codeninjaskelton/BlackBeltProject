using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LevelEditorCamera : MonoBehaviour
{
    public CinemachineVirtualCamera cmvc;

    public Vector3 mouseStart;

    public float dragSpeed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            //mouseStart = (Input.mousePosition);
        }
        
        if (Input.GetKey(KeyCode.Mouse1))
        {
            //Vector3 pos = Camera.main.ScreenToWorldPoint(mouseStart-Input.mousePosition);
            //Vector3 move = new Vector3(pos.x * dragSpeed / 100, pos.y * dragSpeed / 100, -10);
            Vector3 deltaPos = new Vector3(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            cmvc.transform.Translate(-deltaPos);
            //cmvc.transform.position = move;
        }
    }
}
