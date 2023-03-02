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
    public Light directionalLight;
    public Light beanLight;

    private void Start()
    {
        background = GameObject.FindGameObjectWithTag("Backdrop").GetComponent<MeshRenderer>();
        directionalLight = GameObject.Find("Directional Light").GetComponent<Light>();
    }

    private void Update()
    {
        directionalLight.intensity = PlayerPrefs.GetFloat("Brightness");
        time += Time.deltaTime * speed;
        
        /*
        Color a = Color.red;
        Color b = Color.blue;
        currentColour = Color.Lerp(Color.HSVToRGB(0f, 1f, 1f) ,Color.HSVToRGB(0.9f, 1f, 1f) , curve.Evaluate(time));
        background.material.color = currentColour;
        //a, b, curve.Evaluate(time)
        */
        
        //get a float that ping pong between 0 and 1... that will represent the hue of our color
        EvaluatedTime = curve.Evaluate(time);
        //we have to make the color
        currentColour = Color.HSVToRGB(EvaluatedTime, 1f, 1f,true);
        //we have to make the background that color
        background.material.color = currentColour;

    }
}
