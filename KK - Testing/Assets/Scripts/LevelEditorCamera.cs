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
            mouseStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition - mouseStart);
            Vector3 move = new Vector3(pos.x * dragSpeed / 100, pos.y * dragSpeed / 100, -10);

            cmvc.transform.position = move;
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        { 
            mouseStart = Input.mousePosition;
        }
    }
}
