using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    public GameObject brightnessSlider;
    public GameObject brightnessText;
    public float brightnessLevel;

    private void Start()
    {
        PlayerPrefs.SetFloat("Brightness", 1f);
        brightnessSlider.GetComponent<Slider>().value = 1 / 800f;
    }

    private void Update()
    {
        brightnessLevel = brightnessSlider.GetComponent<Slider>().value * 800;
        PlayerPrefs.SetFloat("Brightness", brightnessLevel);
        brightnessText.GetComponent<Text>().text = "Brightness " + brightnessLevel;
    }

    public void Reset()
    {
        brightnessSlider.GetComponent<Slider>().value = 1 / 800f;
    }
}
