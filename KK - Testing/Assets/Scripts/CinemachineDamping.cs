using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineDamping : MonoBehaviour
{
    public CinemachineVirtualCamera cm;
    public CinemachineTransposer cmTransposer;
    private GameObject bean;
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;
    public float constantX;
    public float constantY;

    private void Start()
    {
        cm = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        cmTransposer = cm.GetCinemachineComponent<CinemachineTransposer>();
        bean = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        float xx = Mathf.Abs(bean.GetComponent<Rigidbody>().velocity.x);
        float xy = Mathf.Abs(bean.GetComponent<Rigidbody>().velocity.y);



        cmTransposer.m_XDamping = Mathf.Max(maxX, Mathf.Min(minX, minX / xx ) + constantX);
        cmTransposer.m_YDamping = Mathf.Max(maxY, Mathf.Min(minY, minY / xy) + constantY);
    }
}
