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

    Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    void Start()
    {
        BackB.onClick.AddListener(() => Back());
        JumpB.onClick.AddListener(() => ChangeKey(currentKey));
        CrouchB.onClick.AddListener(() => ChangeKey(currentKey));
        LeftB.onClick.AddListener(() => ChangeKey(currentKey));
        RightB.onClick.AddListener(() => ChangeKey(currentKey));

        if(CheckSaves())
        {
            //Debug.Log("Save exists");
            Load();
        }
        else
        {
            //Debug.Log("Save doesn't exist");
            keys.Add("Up", KeyCode.W);
            keys.Add("Down", KeyCode.S);
            keys.Add("Left", KeyCode.A);
            keys.Add("Right", KeyCode.D);
            Save();
        }

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

    //void Update() { }

    void OnGUI()
    {
        if (currentKey != null)
        {
            Event e = Event.current;

            if(e.isKey)
            {
                keys[currentKey.name] = e.keyCode;
                currentKey.GetComponentInChildren<Text>().text = e.keyCode.ToString();
                Save();
                currentKey = null;

                foreach(var k in keys)
                {
                    Debug.Log(k.Key.ToString() + "_ _" + k.Value.ToString());
                }
            }
        }
    }

    private void ChangeKey(GameObject clicked)
    {
        clicked.GetComponentInChildren<Text>().text = "?";
        currentKey = clicked;
    }

    private void Back()
    {
        SceneManager.LoadSceneAsync("settings_menu", LoadSceneMode.Single);
    }

    private void Save()
    {
        //Debug.Log("\tStart save");
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create("./data.sav");

        binaryFormatter.Serialize(file, keys);
        file.Close();
        Debug.Log("\tStop save");
    }

    private void Load()
    {
        //Debug.Log("\tStart load");
        if(CheckSaves())
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Open("./data.sav", FileMode.Open);

            keys = (Dictionary<string, KeyCode>)binaryFormatter.Deserialize(file);
            file.Close();

            /*JumpB.GetComponentInChildren<Text>().text = keys["Up"].ToString();
            CrouchB.GetComponentInChildren<Text>().text = keys["Down"].ToString();
            LeftB.GetComponentInChildren<Text>().text = keys["Left"].ToString();
            RightB.GetComponentInChildren<Text>().text = keys["Right"].ToString();*/
        }
        Debug.Log("\tStop load");
    }

    private bool CheckSaves(string filepath = "./data.sav")
    {
        if (File.Exists(filepath))
            return true;
        return false;
    }
}
