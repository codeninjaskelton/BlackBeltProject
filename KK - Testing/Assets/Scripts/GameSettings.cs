using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    public GameObject brightnessSlider;
    public GameObject brightnessText;
    public float brightnessLevel;
    
    [Header("Cheats")]
    public GameObject cheats;
    public GameObject cheatsToggle;
    public bool On;

    public static bool moon;
    public GameObject moonject;

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

        if (On)
        {
            
            cheats.SetActive(true);
        }
        else
        {
            cheats.SetActive(false);
        }
    }

    public void Reset()
    {
        brightnessSlider.GetComponent<Slider>().value = 1 / 800f;
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
}
