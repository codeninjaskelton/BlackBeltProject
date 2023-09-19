using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time;
    private GameObject timeText;
    private Pause pauseScript;
    public bool canTime = false;

    private void Start()
    {
        timeText = GameObject.Find("TimeText");
        pauseScript = GameObject.Find("GameManager").GetComponent<Pause>();
        if (PlayerPrefs.GetInt("isTimed") == 1)
        {
            time = PlayerPrefs.GetFloat("time");
        }
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("isTimed") == 1 && pauseScript.isPaused == false)
        {
            timeText.SetActive(true);
            timeText.GetComponent<Text>().text = time.ToString();
            if (canTime)
            {
                time += Time.deltaTime;
                PlayerPrefs.SetFloat("time", time);
                float t = Mathf.Round(time * 100) / 100;
                timeText.GetComponent<Text>().text = t.ToString();
            }
        }
        else
        {
            timeText.SetActive(false);
        }
    }
}
