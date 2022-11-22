using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    private ParticleSystem Bounce;

    private void Start()
    {
        Bounce = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<ParticleSystem>();
    }

    public void PBounce()
    {
        Bounce.Play();
    }
}
