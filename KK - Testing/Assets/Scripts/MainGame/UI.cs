using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using System;
public class UI : MonoBehaviour
{
    public Text levelText;
    public string levelNumber;
    private string levelType;
    public GameObject mainMenuButton;
    public GameObject restartLevelButton;
    public bool invis = false;
    public GameObject rock;
    public Image rockImage;
    public float alpha;

    public GameObject message;
    public GameObject messages;
    public List<GameObject> sent = new List<GameObject>();

    public Collectables collectables;
    public GameObject arrow;
    public List<Image> arrowChildren = new List<Image>();
    public GameObject target;
    public bool startedGame;

    public GameObject bean;

    private void Start()
    {
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
        mainMenuButton = GameObject.Find("MainMenuButton");
        restartLevelButton = GameObject.Find("RestartLevelButton");
        levelNumber = SceneManager.GetActiveScene().name;
        rock = GameObject.Find("Rock");
        rockImage = rock.GetComponent<Image>();
        rockImage.material.color = new Color(1, 1, 1, 0);
        messages = GameObject.Find("Messages");
        arrow = GameObject.Find("Arrow");
        arrowChildren = arrow.GetComponentsInChildren<Image>().ToList();
        for (int i = 0; i < arrowChildren.Count; i++)
        {
            arrowChildren[i].enabled = false;
        }
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            bean = GameObject.FindGameObjectWithTag("Player");
        }
        collectables = GetComponent<Collectables>();
        LevelNumber();
    }

    private void Update()
    {
        if (invis)
        {
            mainMenuButton.SetActive(false);
            restartLevelButton.SetActive(false);
        }
        else
        {
            if (CinemachineZoom.gameStarted)
            {
                if (Pause.isPaused)
                {
                    mainMenuButton.SetActive(true);
                    restartLevelButton.SetActive(true);
                    for (int i = 0; i < arrowChildren.Count; i++)
                    {
                        arrowChildren[i].enabled = false;
                    }
                }
                else
                {
                    mainMenuButton.SetActive(false);
                    restartLevelButton.SetActive(false);
                    for (int i = 0; i < arrowChildren.Count; i++)
                    {
                        arrowChildren[i].enabled = true;
                    }
                }
            }

            if (CinemachineZoom.gameStarted && !startedGame)
            {
                startedGame = true;
                for (int i = 0; i < arrowChildren.Count; i++)
                {
                    arrowChildren[i].enabled = true;
                }
            }
            
        }

        if (Input.GetKeyDown(ControlScript.Hide))
        {
            Toggle(invis);
        }

        if (collectables.collectableNumber == 0)
        {
            target = collectables.portal;
        }
        else
        {
            target = collectables.collectables[collectables.collectables.Count - collectables.collectableNumber];
        }
        
        if (bean) {
            arrow.transform.up = target.transform.position - bean.transform.position;
        }
        else {
            arrow.transform.up = target.transform.position;
        }
        
        
    }

    public void LevelNumber()
    {
        string lvl = "";
        string tst = "";
        if (levelNumber.Length >= 6)
        {
            for (int i = 0; i < 5; i++)
            {
                lvl += levelNumber[i];
            }
        }
        if (levelNumber.Length >= 8)
        {
            for (int i = 0; i < 7; i++)
            {
                tst += levelNumber[i];
            }
        }
        
        if (lvl == "Level")
        {
            levelType = "Level";
        }
        else if (tst == "Testing")
        {
            levelType = "Testing";
        }
        if (levelType == "Testing" && levelNumber.Length != 7)
        {
            if (levelNumber.Length > levelType.Length)
            {
                string levelName = "";
                levelText.text = levelName;
                for (int i = 0; i < levelType.Length; i++)
                {
                        levelName += levelNumber[i];
                }
                if (levelName == levelType)
                {
                    string level = "";
                    for (int i = levelType.Length; i < levelNumber.Length; i++)
                    {
                        level += levelNumber[i];
                    }
                    int ret = 0;
                    if (int.TryParse(level, out ret))
                    {
                        if (ret < 10)
                        {
                            levelText.text += 0;
                        }
                    }
                    levelText.text += level;
                }
            }
        }
        
    }

    public void Toggle(bool bbool)
    {
        int toggle;
        if (bbool)
        {
            toggle = 1;
        }
        else
        {
            toggle = 0;
        }

        if (toggle == 1)
        {
            invis = false;
        }
        if (toggle == 0)
        {
            invis = true;
        }
    }
    public void StartRock()
    {
        StartCoroutine(Rock());
    }
    public IEnumerator Rock()
    {
        rockImage.material.color = new Color(1, 1, 1, 1);
        alpha = 1;
        bool check = true;
        while (check)
        {
            alpha -= 0.01f;
            rockImage.material.color = new Color(1, 1, 1, alpha);
            yield return new WaitForEndOfFrame();
            if (alpha < 0)
            {
                check = false;
            }

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