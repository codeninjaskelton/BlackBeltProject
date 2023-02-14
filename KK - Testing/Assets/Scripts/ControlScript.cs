using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class ControlScript : MonoBehaviour
{
    public bool boolean = false;

    [Header("Left")]
    public bool left = false;
    public static KeyCode Left = KeyCode.A;
    public GameObject leftJect;
    
    [Header("Right")]
    public bool right = false;
    public static KeyCode Right = KeyCode.D;
    public GameObject rightJect;

    [Header("Pause")]
    public bool pause = false;
    public static KeyCode Pause = KeyCode.P;
    public GameObject pauseJect;

    // Start is called before the first frame update
    void Start()
    {
        Left = KeyCode.A;
        Right = KeyCode.D;
        Pause = KeyCode.P;
    }

    // Update is called once per frame
    void Update()
    {
        if (boolean && Input.anyKeyDown)
        {
            foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(kcode))
                {
                    if (left)
                    {
                        Left = kcode;
                        left = false;
                    }
                    if (right)
                    {
                        Right = kcode;
                        right = false;
                    }
                    if (pause)
                    {
                        Pause = kcode;
                        pause = false;
                    }
                    boolean = false;


                }
            }
        }

        leftJect.GetComponent<Text>().text = Left.ToString();
        rightJect.GetComponent<Text>().text = Right.ToString();
        pauseJect.GetComponent<Text>().text = Pause.ToString();
    }

    public void ResetButton()
    {
        Left = KeyCode.A;
        Right = KeyCode.D;
        Pause = KeyCode.P;
    }

    public void LeftButton()
    {
        boolean = true;
        left = true;
    }
    
    public void RightButton()
    {
        boolean = true;
        right = true;
    }

    public void PauseButton()
    {
        boolean = true;
        pause = true;
    }
}
