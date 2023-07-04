using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    private ParticleSystem bounce;
    private TrailRenderer beanTrail;
    private AudioSource beanSound;

    private void Start()
    {
        bounce = transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
        beanTrail = transform.GetChild(1).gameObject.GetComponent<TrailRenderer>();
        beanSound = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        beanTrail.time = PlayerPrefs.GetFloat("TrailLength");
        beanTrail.gameObject.SetActive(true);
        if (PlayerPrefs.GetFloat("TrailLength") == 0)
        {
            beanTrail.gameObject.SetActive(false);
        }
    }

    public void PBounce()
    {
        bounce.Play();

        beanSound.Play();
        beanSound.time = 0.1f;
    }
}
