using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    private ParticleSystem bounce;
    private TrailRenderer beanTrail;
    

    private void Start()
    {
        bounce = transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
        beanTrail = transform.GetChild(1).gameObject.GetComponent<TrailRenderer>();
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
    }
}
