using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    public GameObject brightnessSlider;
    public float brightnessLevel;

    private void Start()
    {
        PlayerPrefs.SetFloat("Brightness", 1f);
    }

    private void Update()
    {
        brightnessLevel = brightnessSlider.GetComponent<Slider>().value * 800;
        PlayerPrefs.SetFloat("Brightness", brightnessLevel);
    }
}
