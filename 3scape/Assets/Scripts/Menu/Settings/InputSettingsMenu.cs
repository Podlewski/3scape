using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

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

        if (CheckSaves())
        {
            Load();
        }
        else
        {
            keys.Add("JumpB", KeyCode.W);
            keys.Add("CrouchB", KeyCode.S);
            keys.Add("LeftB", KeyCode.A);
            keys.Add("RightB", KeyCode.D);
            Save();
        }

        JumpB.GetComponentInChildren<Text>().text = keys["JumpB"].ToString();
        CrouchB.GetComponentInChildren<Text>().text = keys["CrouchB"].ToString();
        LeftB.GetComponentInChildren<Text>().text = keys["LeftB"].ToString();
        RightB.GetComponentInChildren<Text>().text = keys["RightB"].ToString();
    }

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
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create("./data.sav");

        binaryFormatter.Serialize(file, keys);
        file.Close();
    }

    private void Load()
    {
        if(CheckSaves())
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Open("./data.sav", FileMode.Open);

            keys = (Dictionary<string, KeyCode>)binaryFormatter.Deserialize(file);
            file.Close();
        }
    }

    private bool CheckSaves(string filepath = "./data.sav")
    {
        //if (File.Exists(filepath))
        //    return true;
        return File.Exists(filepath);
    }
}
