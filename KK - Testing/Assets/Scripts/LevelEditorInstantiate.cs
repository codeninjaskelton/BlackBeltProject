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

    [Header("Mouse")]
    public bool canPlace;

    [Header("Boundaries")]
    public Boundaries boundaries;
    public bool isInBoundaries;

    public List<GameObject> placed = new List<GameObject>();

    private void Start()
    {
        canPlace = false;
    }

    private void Update()
    {
        var child0 = transform.GetChild(0);
        var child1 = transform.GetChild(1);
        
        child0.gameObject.SetActive(false);
        child1.gameObject.SetActive(false);
        switch (currentItem)
        {
            
            case 0:
                itemParent = Blocks;
                child0.gameObject.SetActive(true);
                break;
            case 1:
                child1.gameObject.SetActive(true);
                break;
            
        }

        if (canPlace == false || isInBoundaries == false)
        {
            child0.gameObject.SetActive(false);
            child1.gameObject.SetActive(false);
        }
        Debug.Log(boundaries);
        if (transform.position.y > boundaries.boundaries[0] && transform.position.y < boundaries.boundaries[1] && transform.position.x > boundaries.boundaries[2] && transform.position.x < boundaries.boundaries[3])
        {
            isInBoundaries = true;
        }
        else
        {
            isInBoundaries = false;
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
            
            
            if (canPlace == true && isInBoundaries == true)
            {
                placed.Add(Instantiate(editorItems[currentItem], new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0), Quaternion.Euler(0, 0, itemRotation), itemParent.transform));
                
            }
            
            

        }
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        transform.rotation = Quaternion.Euler(0, 0, itemRotation);

        if (Input.GetKeyDown(KeyCode.V))
        {
            canPlace = true;
        }
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            canPlace = false;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            
        }
    }

    public void ChangeItem(int number)
    {
        currentItem = number;
    }
}
