using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private void Start()
    {
        levelEditorInstantiate = gameObject.GetComponent<LevelEditorInstantiate>();
        levelEditorManager = gameObject.GetComponent<LevelEditorManager>();
    }

    private void Update()
    {
        blockLimitText.text = levelEditorInstantiate.placed.Count + "/" + levelEditorInstantiate.blockLimit;
        if (levelEditorManager.hobject != null)
        {
            transX.text = (levelEditorManager.hobject.transform.position.x * 10).ToString();
            transY.text = (levelEditorManager.hobject.transform.position.y * 10).ToString();
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
}
