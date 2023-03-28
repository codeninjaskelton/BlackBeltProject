using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditorInstantiate : MonoBehaviour
{
    public GameObject[] editorItems;
    public int currentItem;
    
    [Header("Item Parents")]
    public GameObject itemParent;
    public GameObject Blocks;
    public GameObject Collectables;

    [Header("Rotation")]
    public float itemRotation = 0;
    public float rotationSpeed = 100;

    private void Update()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        switch (currentItem)
        {
            
            case 0:
                itemParent = Blocks;
                transform.GetChild(0).gameObject.SetActive(true);
                break;
            case 1:
                transform.GetChild(1).gameObject.SetActive(true);
                break;
            
        }
        
        
        if (Input.GetKey(KeyCode.Q))
        {
            itemRotation -= 1 * rotationSpeed/100;
        }
        if (Input.GetKey(KeyCode.E))
        {
            itemRotation += 1 * rotationSpeed/100;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(editorItems[currentItem], new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0), Quaternion.Euler(0, 0, itemRotation), itemParent.transform);

        }
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        transform.rotation = Quaternion.Euler(0, 0, itemRotation);
    }

    public void ChangeItem(int number)
    {
        currentItem = number;
    }
}
