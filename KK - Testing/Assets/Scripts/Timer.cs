using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time;
    private GameObject timeText;
    public bool canTime = false;

    private void Start()
    {
        timeText = GameObject.Find("TimeText");
        if (PlayerPrefs.GetInt("isTimed") == 1)
        {
            time = PlayerPrefs.GetFloat("time");
        }
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("isTimed") == 1)
        {
            timeText.SetActive(true);
            timeText.GetComponent<Text>().text = time.ToString();
            if (canTime)
            {
                time += Time.deltaTime;
                PlayerPrefs.SetFloat("time", time);
                timeText.GetComponent<Text>().text = time.ToString();
            }
        }
        else
        {
            timeText.SetActive(false);
        }
    }
}
