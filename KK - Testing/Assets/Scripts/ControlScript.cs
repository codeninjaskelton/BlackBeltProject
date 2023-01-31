using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScript : MonoBehaviour
{
    public bool boolean = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (boolean && Input.anyKeyDown)
        {
            
        }
    }

    public void ButtonPress()
    {
        boolean = true;
    }
}
