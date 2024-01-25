using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls the UI of the Level Editor
/// </summary>
public class LevelEditorUI : MonoBehaviour
{
    public Text blockLimitText;
    public LevelEditorInstantiate levelEditorInstantiate;
    public LevelEditorManager levelEditorManager;

    public GameObject message;
    public GameObject messages;

    public InputField transX;
    public InputField transY;

    public List<GameObject> sent = new List<GameObject>();

    public Boundaries boundaries;
    public GameObject BoundarySize;
    private InputField BoundaryInputField;

    public Toggle toggleSave;
    public GameObject Save;
    public GameObject Load;

    private void Start()
    {
        levelEditorInstantiate = gameObject.GetComponent<LevelEditorInstantiate>();
        levelEditorManager = gameObject.GetComponent<LevelEditorManager>();
        BoundaryInputField = BoundarySize.transform.GetChild(1).gameObject.GetComponent<InputField>();
        BoundarySize.SetActive(true);

    }

    private void Update()
    {
        

        blockLimitText.text = levelEditorInstantiate.placed.Count + "/" + levelEditorInstantiate.blockLimit;

        if (toggleSave.isOn)
        {
            Save.SetActive(true);
            Load.SetActive(true);
        }
        else
        {
            Save.SetActive(false);
            Load.SetActive(false);
        }
    }

    public void CallNewMessage(string Message)
    {
        StartCoroutine(NewMessage(Message));
    }
    public IEnumerator NewMessage(string Message)
    {
        var newMessage = Instantiate(message, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), messages.transform);
        foreach (GameObject gobject in sent)
        {
            gobject.transform.position += new Vector3(0, 20f, 0);
            

        }
        sent.Add(newMessage);
        var newMessageText = newMessage.GetComponent<Text>();
        newMessageText.text = Message;
        newMessage.GetComponent<RectTransform>().localPosition = Vector2.zero;

        while (newMessageText.color.a < 1)
        {
            var newMessageTextColor = newMessageText.color;
            newMessageTextColor.a += 0.1f;
            newMessageText.color = newMessageTextColor;

            yield return new WaitForSeconds(Time.deltaTime);
        }

        while (newMessageText.color.a > 0)
        {
            var newMessageTextColor = newMessageText.color;
            newMessageTextColor.a -= 0.01f;
            newMessageText.color = newMessageTextColor;

            yield return new WaitForSeconds(0.02f);
        }

        sent.RemoveAt(0);
        Destroy(newMessage);
    }

    public void BoundaryEntered()
    {
        BoundarySize.SetActive(false);
        if (int.TryParse(BoundaryInputField.text, out int boundaryS))
        {
            boundaries.boundaryScale = boundaryS;
        }
        
    }
}
