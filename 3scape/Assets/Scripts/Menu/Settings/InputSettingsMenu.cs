using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputSettingsMenu : MonoBehaviour
{
    public Button BackB;
    public Text JumpT;
    public Text CrouchT;
    public Text LeftT;
    public Text RightT;
    public Button JumpB;
    public Button CrouchB;
    public Button LeftB;
    public Button RightB;
    private GameObject currentKey;

    public static InputSettingsMenu settings;

    Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    void Start()
    {
        BackB.onClick.AddListener(() => Back());
        JumpB.onClick.AddListener(() => ChangeKey(currentKey));
        CrouchB.onClick.AddListener(() => ChangeKey(currentKey));
        LeftB.onClick.AddListener(() => ChangeKey(currentKey));
        RightB.onClick.AddListener(() => ChangeKey(currentKey));

        keys.Add("Up", KeyCode.W);
        keys.Add("Down", KeyCode.S);
        keys.Add("Left", KeyCode.A);
        keys.Add("Right", KeyCode.D);

        JumpB.GetComponentInChildren<Text>().text = keys["Up"].ToString();
        CrouchB.GetComponentInChildren<Text>().text = keys["Down"].ToString();
        LeftB.GetComponentInChildren<Text>().text = keys["Left"].ToString();
        RightB.GetComponentInChildren<Text>().text = keys["Right"].ToString();
    }

    /*void Awake()
    {
        if(settings == null)
        {
            DontDestroyOnLoad(gameObject);
            settings = this;
        }
        else if(settings != this)
        {
            Destroy(gameObject);
        }
    }*/

    void Update()
    {
    }

    void OnGUI()
    {
        if (currentKey != null)
        {
            Event e = Event.current;

            if(e.isKey)
            {
                keys[currentKey.name] = e.keyCode;
                currentKey.GetComponentInChildren<Text>().text = e.keyCode.ToString();
                currentKey = null;
            }
        }
    }

    public void ChangeKey(GameObject clicked)
    {
        clicked.GetComponentInChildren<Text>().text = "?";
        currentKey = clicked;
    }

    private void Back()
    {
        SceneManager.LoadSceneAsync("settings_menu", LoadSceneMode.Single);
    }

    public void Save()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Open("./saves/data.sav", FileMode.Open);

        Data data = new Data();
        // data.sth = sth;

        binaryFormatter.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if(File.Exists("./saves/data.sav"))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Create("./saves/data.sav");

            Data data = (Data)binaryFormatter.Deserialize(file);
            file.Close();

            // sth = data.sth
        }
    }

    private KeyCode GetKey()
    {
        foreach(KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
        {
            if(Input.GetKeyDown(keyCode))
            {
                Debug.Log("yes" + keyCode);
                return keyCode;
            }
            Debug.Log("no" + keyCode);
        }

        throw new Exception();
    }
}

[Serializable]
class Data { }
