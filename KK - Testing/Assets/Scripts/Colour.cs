using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colour : MonoBehaviour
{
    public float time;
    public AnimationCurve curve;
    public MeshRenderer background;
    Color currentColour;

    private void Start()
    {
        background = GameObject.Find("Backdrop").GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        time += Time.deltaTime * 0.01f;

        currentColour = Color.Lerp(Color.HSVToRGB(0f, 1f, 1f) ,Color.HSVToRGB(1f, 1f, 1f) , curve.Evaluate(time));
        background.material.color = currentColour;
    }
}
