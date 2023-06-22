using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string nextScene;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(nextScene);
        }
    }

    public void SceneLoad(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void MainMenuLoad()
    {
        SceneManager.LoadScene(0);
    }
}
