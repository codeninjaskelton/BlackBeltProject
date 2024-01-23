using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public static GameObject music;
    public GameObject audioSource;
    void Start()
    {
        if (music != null)
        {

        }
        else
        {
            music = Instantiate(audioSource);
        }
    }
}
