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
    public Pause pause;
    public GameObject boundary;
    public float ogtimescale;

    private void Start()
    {
        bean = GameObject.Find("Bean");
        portal = GameObject.Find("Portal");
        collectables = GameObject.Find("GameManager").GetComponent<Collectables>().collectables;
        collectablesScript = GameObject.Find("GameManager").GetComponent<Collectables>();
        timer = GameObject.Find("GameManager").GetComponent<Timer>();
        pause = GameObject.Find("GameManager").GetComponent<Pause>();
        cm = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        cm.m_Lens.OrthographicSize = startZoom;
        cm.m_Follow = null;
        ogtimescale = Time.timeScale;
        boundary = GameObject.Find("Boundary");
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
        if (player)
        {
            bean.GetComponent<Rigidbody>().isKinematic = false;
        }
        if (exit)
        {
            portal.SetActive(false);
        }
        if (items.Length > 0)
        {
            collectablesScript.Begin();
        }
        if (PlayerPrefs.GetInt("isTimed") == 1)
        {
            timer.canTime = true;
        }
        while (cm.m_Lens.OrthographicSize > endZoom)
        {
            elasped += Time.deltaTime / duration;
            yield return new WaitForSeconds(0.0001f);
            cm.m_Lens.OrthographicSize = Mathf.Lerp(startZoom, endZoom, elasped);
        }
    }
    
    public void Pause()
    {
        cm.m_Lens.OrthographicSize = startZoom;
        cm.m_Follow = null;
        cm.transform.position = new Vector3(0, 0, -10);
        //bean.GetComponent<Rigidbody>().isKinematic = true;
        Time.timeScale = 0;
        
    }

    public IEnumerator PauseZoom(GameObject player, GameObject exit, GameObject[] items)
    {
        
        cm.m_Follow = player.transform;
        //bean.GetComponent<Rigidbody>().isKinematic = false;
        Time.timeScale = ogtimescale;
        if (PlayerPrefs.GetInt("isTimed") == 1)
        {
            timer.canTime = true;
        }
        while (cm.m_Lens.OrthographicSize > endZoom)
        {
            elasped += Time.deltaTime / duration;
            yield return new WaitForSeconds(0.0001f);
            cm.m_Lens.OrthographicSize = Mathf.Lerp(startZoom, endZoom, elasped);
        }
        
    }
}
