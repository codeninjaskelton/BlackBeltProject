using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject controls;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            int toggle;
            if (controls.activeInHierarchy == true)
            {
                toggle = 1;
            }
            else
            {
                toggle = 0;
            }
            
            if (toggle == 1)
            {
                controls.SetActive(false);
            }
            if (toggle == 0)
            {
                controls.SetActive(true);
            }
        }
    }
}
