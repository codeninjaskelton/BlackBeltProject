using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    public GameObject brightnessSlider;
    public GameObject brightnessText;
    public float brightnessLevel;
    public GameObject[] cheats;
    private GameObject cheatsToggle;

    private void Start()
    {
        cheatsToggle = GameObject.Find("CheatsToggle");
        PlayerPrefs.SetFloat("Brightness", 1f);
        brightnessSlider.GetComponent<Slider>().value = 1 / 800f;
    }

    private void Update()
    {
        brightnessLevel = brightnessSlider.GetComponent<Slider>().value * 800;
        PlayerPrefs.SetFloat("Brightness", brightnessLevel);
        brightnessText.GetComponent<Text>().text = "Brightness " + brightnessLevel;

        if (cheatsToggle.GetComponent<Toggle>().isOn)
        {
            for (int i = 0; i < cheats.Length; i++)
            {
                cheats[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < cheats.Length; i++)
            {
                cheats[i].SetActive(false);
            }
        }
    }

    public void Reset()
    {
        brightnessSlider.GetComponent<Slider>().value = 1 / 800f;
    }
}
