using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Instantiate objects in the Level Editor
/// </summary>
public class LevelEditorInstantiate : MonoBehaviour
{
    public GameObject[] editorItems;
    public int currentItem;


    [Header("Item Parents")]
    public GameObject itemParent;
    public GameObject Blocks;
    public GameObject Collectables;

    [Header("Position")]
    public Vector2 transPos;
    public InputField posX;
    public InputField posY;

    [Header("Rotation")]
    public float itemRotation = 0;
    public float rotationSpeed = 100;
    public InputField rotZ;

    [Header("Scale")]
    public Vector2 transScale;
    public InputField scaleX;
    public InputField scaleY;

    [Header("Mouse")]
    public bool canPlace;
    public bool followingMouse;

    [Header("Boundaries")]
    public Boundaries boundaries;
    public bool isInBoundaries;
    public InputField boundaryScale;

    public List<GameObject> placed = new List<GameObject>();

    public float blockLimit;

    public LevelEditorUI levelEditorUI;

    private void Start()
    {
        canPlace = false;
        boundaryScale.text = boundaries.boundaryScale.ToString();
    }

    private void Update()
    {
        GameObject child0 = transform.GetChild(0).gameObject;
        GameObject child1 = transform.GetChild(1).gameObject;
        GameObject child2 = transform.GetChild(2).gameObject;
        GameObject child3 = transform.GetChild(3).gameObject;
        GameObject child4 = transform.GetChild(4).gameObject;
        GameObject child5 = transform.GetChild(5).gameObject;

        if (canPlace)
        {
            if (float.TryParse(posX.text.ToString(), out float retX))
            {
                transPos.x = retX;
            }
            if (float.TryParse(posY.text.ToString(), out float retY))
            {
                transPos.y = retY;
            }
            if (float.TryParse(rotZ.text.ToString(), out float retZ))
            {
                itemRotation = retZ;
            }
            if (rotZ.text == "")
            {
                itemRotation = 0;
            }
            if (float.TryParse(scaleX.text.ToString(), out float retSX))
            {
                transScale.x = retSX;
            }
            if (float.TryParse(scaleY.text.ToString(), out float retSY))
            {
                transScale.x = retSY;
            }
        }
        
        child0.SetActive(false);
        child1.SetActive(false);
        child2.SetActive(false);
        child3.SetActive(false);
        child4.SetActive(false);
        child5.SetActive(false);

        switch (currentItem)
        {

            case 0:
                itemParent = Blocks;
                child0.gameObject.SetActive(true);
                break;
            case 1:
                itemParent = Collectables;
                child1.gameObject.SetActive(true);
                break;
            case 2:
                child2.gameObject.SetActive(true);
                break;
            case 3:
                child3.gameObject.SetActive(true);
                break;
            case 4:
                child4.gameObject.SetActive(true);
                break;
            case 5:
                child5.gameObject.SetActive(true);
                break;

        }

        if (canPlace == false || !isInBoundaries)
        {
            child0.gameObject.SetActive(false);
            child1.gameObject.SetActive(false);
            child2.gameObject.SetActive(false);
            child3.gameObject.SetActive(false);
            child4.gameObject.SetActive(false);
            child5.gameObject.SetActive(false);
        }

        blockLimit = boundaries.boundaryScale * 20;

        if (Input.mousePosition.x / Screen.width > 0.205 && Input.mousePosition.y / Screen.height > 0.18)
        {
            isInBoundaries = true;
        }
        else if (followingMouse)
        {
            isInBoundaries = false;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            itemRotation += 1 * rotationSpeed / 100;
        }
        if (Input.GetKey(KeyCode.E))
        {
            itemRotation -= 1 * rotationSpeed / 100;
        }


        if (Input.GetMouseButtonDown(0))
        {
            if (canPlace && followingMouse && isInBoundaries)
            {
                
                if (levelEditorUI.BoundarySize.activeInHierarchy)
                {
                    levelEditorUI.CallNewMessage("Enter Boundary Size");
                }
                else
                {
                    Debug.Log("x% = " + Input.mousePosition.x / Screen.width);
                    Debug.Log("y% = " + Input.mousePosition.y / Screen.height);

                    if (placed.Count < blockLimit)
                    {
                        switch (currentItem)
                        {
                            case 2:
                        if (GameObject.FindGameObjectWithTag("Player") == null)
                        {
                            placed.Add(Instantiate(editorItems[currentItem], new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0), Quaternion.Euler(0, 0, itemRotation), itemParent.transform));
                        }
                        else
                        {
                            levelEditorUI.CallNewMessage("Cannot Have More Than One Bean");
                        }
                        break;

                            case 3:
                        if (GameObject.FindGameObjectWithTag("Portal") == null)
                        {
                            placed.Add(Instantiate(editorItems[currentItem], new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0), Quaternion.Euler(0, 0, itemRotation), itemParent.transform));
                        }
                        else
                        {
                            levelEditorUI.CallNewMessage("Cannot Have More Than One Portal");
                        }
                        break;

                            default:
                        placed.Add(Instantiate(editorItems[currentItem], new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0), Quaternion.Euler(0, 0, itemRotation), itemParent.transform));
                        break;
                        }

                        
                                
                    }
                    else
                    {
                        levelEditorUI.CallNewMessage("Cannot Place Anymore Blocks");
                    }
                }
                        

                


            }



        }
        else if (canPlace)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                if (placed.Count < blockLimit)
                {

                    placed.Add(Instantiate(editorItems[currentItem], new Vector3(transPos.x, transPos.y, 0) / 10, Quaternion.Euler(0, 0, itemRotation), itemParent.transform));

                }
                else
                {
                    levelEditorUI.CallNewMessage("Cannot Place Anymore Blocks");

                }
            }
        }



        if (followingMouse)
        {
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        }
        else
        {
            transform.position = new Vector3(transPos.x, transPos.y, 0) / 10;
        }


        transform.rotation = Quaternion.Euler(0, 0, itemRotation);

        if (Input.GetKeyDown(ControlScript.Place))
        {
            canPlace = true;
        }

        if (Input.GetKeyDown(ControlScript.Select))
        {
            canPlace = false;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (placed.Count > 0)
            {
                Destroy(placed[placed.Count - 1]);
                placed.RemoveAt(placed.Count - 1);
            }

        }
        //Messes with level editor object transformations
        //if (Input.GetKeyDown(KeyCode.T))
        //{
        //    if (followingMouse)
        //    {
        //        followingMouse = false;
        //    }
        //    else
        //    {
        //        followingMouse = true;
        //    }
        //}

        

    }

    public void ChangeItem(int number)
    {
        currentItem = number;
    }
}
