using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameSettings : MonoBehaviour
{
    [Header("Brightness")]
    public GameObject brightnessSlider;
    public GameObject brightnessText;
    public float brightnessLevel;
    
    [Header("Cheats")]
    public GameObject cheats;
    public GameObject cheatsToggle;
    public bool On;
    
    public static bool moon;
    public GameObject moonject;

    [Header("Trail")]
    public GameObject trailLengthInputField;
    public GameObject trailLengthText;
    public static float trailLength;

    [Header("Background")]
    public Toggle rainbowToggle;
    public Slider rainbowSlider;
    public Text rainbowSliderText;

    private void Start()
    {
        PlayerPrefs.SetFloat("Brightness", 1f);
        PlayerPrefs.SetFloat("TrailLength", float.PositiveInfinity);
        brightnessSlider.GetComponent<Slider>().value = 1 / 800f;
        rainbowSlider.value = 0f;
        PlayerPrefs.SetFloat("Rainbow", 0);
        PlayerPrefs.SetFloat("RainbowColor", 0);
    }

    private void Update()
    {
        brightnessLevel = brightnessSlider.GetComponent<Slider>().value * 800;
        PlayerPrefs.SetFloat("Brightness", brightnessLevel);
        PlayerPrefs.SetFloat("TrailLength", trailLength);
        brightnessText.GetComponent<Text>().text = "Brightness " + brightnessLevel;
        rainbowSliderText.text = "Background Color " + rainbowSlider.value;
        PlayerPrefs.SetFloat("RainbowColor", rainbowSlider.value);

        if (On)
        {
            
            cheats.SetActive(true);
        }
        else
        {
            cheats.SetActive(false);
        }

        if (rainbowToggle.isOn)
        {
            PlayerPrefs.SetFloat("Rainbow", 1);
        }
        else
        {
            PlayerPrefs.SetFloat("Rainbow", 0);
        }

    }

    public void Reset()
    {
        brightnessSlider.GetComponent<Slider>().value = 1 / 800f;
        trailLength = float.PositiveInfinity;
        rainbowToggle.isOn = false;
        rainbowSlider.value = 0;

    }

    public void ToggleCheats(GameObject toggleject)
    {
        if (toggleject.name == "CheatsToggle")
        {
            On = toggleject.GetComponent<Toggle>().isOn;
            if (!On)
            {
                moonject.GetComponent<Toggle>().isOn = false;
            }
        }
        if (toggleject.name == "MoonToggle")
        {
            moon = toggleject.GetComponent<Toggle>().isOn;
        }
        
    }

    public void TrailLengthCheck()
    {
        
        if (float.TryParse(trailLengthText.GetComponent<InputField>().text, out float ret))
        {
            trailLength = ret;
        }
        if (trailLengthText.GetComponent<InputField>().text == "infinity")
        {
            trailLength = float.PositiveInfinity;
        }
    }
}
