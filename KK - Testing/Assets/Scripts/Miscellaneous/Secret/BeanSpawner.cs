using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanSpawner : MonoBehaviour
{
    public GameObject ground;
    public GameObject bean;
    public GameObject[] beanChild = new GameObject[9];

    // Start is called before the first frame update
    void Start()
    {
        bean = GameObject.Find("BeanParent");
        for (int i = 0; i < 9; i++)
        {
            beanChild[i] = bean.transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 9; i++)
        {
            if (!beanChild[i].GetComponent<Range>().isTouching)
            {

            }
        }
    }
}
