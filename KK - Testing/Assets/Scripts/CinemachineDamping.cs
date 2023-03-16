using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineDamping : MonoBehaviour
{
    public CinemachineVirtualCamera cm;
    public CinemachineTransposer cmTransposer;
    private GameObject bean;

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



        cmTransposer.m_XDamping = Mathf.Min(1, 1 / xx);
        cmTransposer.m_YDamping = Mathf.Min(1, 1 / xy);
    }
}
