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
    public GameObject bean;
    public GameObject portal;
    public GameObject[] collectables;
    public Collectables collectablesScript;
    public Timer timer;

    private void Start()
    {
        bean = GameObject.Find("Bean");
        portal = GameObject.Find("Portal");
        collectables = GameObject.Find("GameManager").GetComponent<Collectables>().collectables;
        collectablesScript = GameObject.Find("GameManager").GetComponent<Collectables>();
        timer = GameObject.Find("GameManager").GetComponent<Timer>();
        cm = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        cm.m_Lens.OrthographicSize = startZoom;
        cm.m_Follow = null;
        bean.GetComponent<Rigidbody>().isKinematic = true;
        portal.SetActive(true);
        for (int i = 0; i < collectables.Length; i++)
        {
            collectables[i].SetActive(true);
        }
        StartCoroutine(EndZoom(bean, portal, collectables));
    }

    public IEnumerator EndZoom(GameObject player, GameObject exit, GameObject[] items)
    {
        yield return new WaitForSeconds(3);
        cm.m_Follow = player.transform;
        bean.GetComponent<Rigidbody>().isKinematic = false;
        portal.SetActive(false);
        collectablesScript.Begin();
        timer.canTime = true;
        while (cm.m_Lens.OrthographicSize > endZoom)
        {
            elasped += Time.deltaTime / duration;
            yield return new WaitForSeconds(0.0001f);
            cm.m_Lens.OrthographicSize = Mathf.Lerp(startZoom, endZoom, elasped);
        }
    }
}
