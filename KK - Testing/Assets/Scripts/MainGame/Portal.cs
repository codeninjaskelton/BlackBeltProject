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
            if (nextScene == "StartScreen")
            {
                PlayerPrefs.SetFloat("LastV", PlayerPrefs.GetFloat("time"));
            }
            
            if (nextScene == null)
            {
                SceneManager.LoadScene("StartScreen");
            }
            else
            {
                if (nextScene == "LStartScreen")
                {
                    nextScene = "StartScreen";
                }
                SceneManager.LoadScene(nextScene);
            }
            
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

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}