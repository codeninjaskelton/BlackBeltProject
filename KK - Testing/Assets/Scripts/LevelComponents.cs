using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComponents : MonoBehaviour
{
    public string sceneName;

    private void Start()
    {
        if (sceneName == "Testing6")
        {
            Physics.gravity = new Vector3(0, -1.62f);
        }
        if (sceneName == ":(")
        {
            Physics.gravity = new Vector3(0, -0.1f);
        }
    }

    private void Update()
    {
        
    }
}
