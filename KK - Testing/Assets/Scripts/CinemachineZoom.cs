using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineZoom : MonoBehaviour
{
    private CinemachineVirtualCamera cm;

    private void Start()
    {
        cm = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
    }


}
