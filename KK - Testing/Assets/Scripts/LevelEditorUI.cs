using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEditorUI : MonoBehaviour
{
    public Text blockLimitText;
    public LevelEditorInstantiate levelEditorInstantiate;

    public GameObject message;
    public GameObject messages;

    private void Start()
    {
        levelEditorInstantiate = gameObject.GetComponent<LevelEditorInstantiate>();
    }

    private void Update()
    {
        blockLimitText.text = levelEditorInstantiate.placed.Count + "/" + levelEditorInstantiate.blockLimit;
    }

    public void CallNewMessage(string Message)
    {
        StartCoroutine(NewMessage(Message));
    }
    public IEnumerator NewMessage(string Message)
    {
        var newMessage = Instantiate(message, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), messages.transform);
        var newMessageText = newMessage.GetComponent<Text>();
        newMessageText.text = Message;
        newMessage.GetComponent<RectTransform>().localPosition = Vector2.zero;

        while (newMessageText.color.a < 1)
        {
            var newMessageTextAlpha = newMessageText.color.a;
            newMessageTextAlpha += 0.1f;

            yield return new WaitForSeconds(Time.deltaTime);
        }

        while (newMessageText.color.a > 1)
        {
            var newMessageTextAlpha = newMessageText.color.a;
            newMessageTextAlpha -= 0.01f;

            yield return new WaitForSeconds(Time.deltaTime);
        }

        Destroy(newMessage);
    }
}
