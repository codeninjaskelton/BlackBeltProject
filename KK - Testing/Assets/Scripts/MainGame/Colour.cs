using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colour : MonoBehaviour
{
    public float time;
    public AnimationCurve curve;
    public MeshRenderer background;
    Color currentColour;
    public float EvaluatedTime;
    public float speed;

    private void Start()
    {
        background = GameObject.FindGameObjectWithTag("Backdrop").GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        
        time += Time.deltaTime * speed / 10;
        EvaluatedTime = curve.Evaluate(time);
        if (PlayerPrefs.GetFloat("Rainbow") == 1)
        {
            currentColour = Color.HSVToRGB(EvaluatedTime, 1f, 1f, true);
        }
        else if (PlayerPrefs.GetFloat("Rainbow") == 0)
        {
            currentColour = Color.HSVToRGB(PlayerPrefs.GetFloat("RainbowColor") / 100f, 1f, 1f, true);
        }

        background.material.color = currentColour;
        
    }
}