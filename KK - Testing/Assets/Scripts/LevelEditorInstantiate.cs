using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public InputField transX;
    public InputField transY;

    [Header("Rotation")]
    public float itemRotation = 0;
    public float rotationSpeed = 100;

    [Header("Mouse")]
    public bool canPlace;
    public bool followingMouse;

    [Header("Boundaries")]
    public Boundaries boundaries;
    public bool isInBoundaries;
    public InputField boundaryScale;

    public List<GameObject> placed = new List<GameObject>();

    public int blockLimit;

    public LevelEditorUI levelEditorUI;

    private void Start()
    {
        canPlace = false;
        boundaryScale.text = boundaries.boundaryScale.ToString();
    }

    private void Update()
    {
        var child0 = transform.GetChild(0);
        var child1 = transform.GetChild(1);

        if (float.TryParse(transX.text.ToString(), out float retX))
        {
            transPos.x = retX;
        }
        if (float.TryParse(transY.text.ToString(), out float retY))
        {
            transPos.y = retY;
        }


        child0.gameObject.SetActive(false);
        child1.gameObject.SetActive(false);

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

        }

        if (canPlace == false || !isInBoundaries)
        {
            child0.gameObject.SetActive(false);
            child1.gameObject.SetActive(false);
        }

        if (Input.mousePosition.x / Screen.width > 0.205 && Input.mousePosition.y / Screen.height > 0.18 && Input.mousePosition.y / Screen.height < 0.88)
        {
            isInBoundaries = true;
        }
        else
        {
            isInBoundaries = false;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            itemRotation -= 1 * rotationSpeed / 100;
        }
        if (Input.GetKey(KeyCode.E))
        {
            itemRotation += 1 * rotationSpeed / 100;
        }


        if (Input.GetMouseButtonDown(0))
        {
            if (canPlace)
            {
                if (followingMouse)
                {
                    if (isInBoundaries)
                    {
                        Debug.Log("x% = " + Input.mousePosition.x / Screen.width);
                        Debug.Log("y% = " + Input.mousePosition.y / Screen.height);
                        
                        if (placed.Count < blockLimit)
                        {
                            placed.Add(Instantiate(editorItems[currentItem], new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0), Quaternion.Euler(0, 0, itemRotation), itemParent.transform));
                        }
                        else
                        {
                            levelEditorUI.CallNewMessage("Cannot Place Anymore Blocks");
                        }
                    }
                }




            }



        }
        else if (canPlace)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                transX.DeactivateInputField();
                transY.DeactivateInputField();

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
            if (placed.Count > 0)
            {
                Destroy(placed[placed.Count - 1]);
                placed.RemoveAt(placed.Count - 1);
            }

        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (followingMouse)
            {
                followingMouse = false;
            }
            else
            {
                followingMouse = true;
            }
        }

        if (float.TryParse(boundaryScale.text, out float ret))
        {
            boundaries.boundaryScale = ret;
        }
        

        //string x = transX.text.ToString();
        //Debug.Log("update");
        //for (int i = 0; i < x.Length; i++)
        //{
        //    if (!int.TryParse(x.Substring(i, 1), out int ret))
        //    {
        //        x.Remove(i, 1);
        //        Debug.Log("running");
        //        transX.text = x;
        //    }
        //}

    }

    public void ChangeItem(int number)
    {
        currentItem = number;
    }
}
