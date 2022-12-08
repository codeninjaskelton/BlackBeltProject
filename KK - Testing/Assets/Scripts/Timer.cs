using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time;

    private void Start()
    {
        time = PlayerPrefs.GetFloat("time");
    }

    private void Update()
    {
        time += Time.deltaTime;
        PlayerPrefs.SetFloat("time", time);
        GameObject.Find("TimeText").GetComponent<Text>().text = time.ToString();
    }
}
