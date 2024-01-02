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

    [Header("Place")]
    public bool place = false;
    public static KeyCode Place = KeyCode.V;
    public GameObject placeJect;

    [Header("Select")]
    public bool select = false;
    public static KeyCode Select = KeyCode.X;
    public GameObject selectJect;

    // Start is called before the first frame update
    void Start()
    {
        Left = KeyCode.A;
        Right = KeyCode.D;
        Pause = KeyCode.P;
        Place = KeyCode.V;
        Select = KeyCode.X;
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
                    if (place)
                    {
                        Place = kcode;
                        place = false;
                    }
                    if (select)
                    {
                        Select = kcode;
                        select = false;
                    }
                    
                    boolean = false;


                }
            }
        }

        leftJect.GetComponent<Text>().text = Left.ToString();
        rightJect.GetComponent<Text>().text = Right.ToString();
        pauseJect.GetComponent<Text>().text = Pause.ToString();
        placeJect.GetComponent<Text>().text = Place.ToString();
        selectJect.GetComponent<Text>().text = Select.ToString();
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

    public void PlaceButton()
    {
        boolean = true;
        place = true;
    }

    public void SelectButton()
    {
        boolean = true;
        select = true;
    }
}
