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

    public List<GameObject> placed = new List<GameObject>();

    public int blockLimit;

    public LevelEditorUI levelEditorUI;

    private void Start()
    {
        canPlace = false;
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

        if (canPlace == false || isInBoundaries == false)
        {
            child0.gameObject.SetActive(false);
            child1.gameObject.SetActive(false);
        }

        if (transform.position.y > (boundaries.boundaries[0]) && transform.position.y < (boundaries.boundaries[1]) && transform.position.x > (boundaries.boundaries[2]) && transform.position.x < (boundaries.boundaries[3]))
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
            if (canPlace == true)
            {
                if (followingMouse)
                {
                    if (isInBoundaries == true)
                    {
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

        for (int i = 0; i < transX.text.ToString().Length; i++)
        {
            int length = transX.text.Length;
            List<string> x;
            List<string> y;
            
            for (int it = 0; it < transX.text.Length; it++)
            {

                x.Add(transX.text[it].ToString());
                if (float.TryParse(transX.text.ToString().Split(char.Parse(x[it]), out float ret))
                {

                }
            }
            
        }
    }

    public void ChangeItem(int number)
    {
        currentItem = number;
    }
}
