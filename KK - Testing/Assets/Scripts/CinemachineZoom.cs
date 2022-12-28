using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineZoom : MonoBehaviour
{
    private CinemachineVirtualCamera cm;
    public float startZoom;
    public float endZoom;
    private float elasped = 0.0f;
    public float duration;

    private void Start()
    {
        cm = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        cm.m_Lens.OrthographicSize = startZoom;
        EndZoom();
    }

    public IEnumerator EndZoom()
    {
        yield return new WaitForSeconds(3);
        while (cm.m_Lens.OrthographicSize > endZoom)
        {
            elasped += Time.deltaTime / duration;
            cm.m_Lens.OrthographicSize = Mathf.Lerp(startZoom, endZoom, elasped);
        }
    }
}
