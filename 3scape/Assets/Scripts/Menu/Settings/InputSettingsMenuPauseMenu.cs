using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputSettingsMenuPauseMenu : MonoBehaviour
{
    public GameObject inputSettingsMenuUI;
    public GameObject settingsMenuUI;
    public Text JumpT;
    public Text CrouchT;
    public Text LeftT;
    public Text RightT;
    public Text RotateT;
    public Text Skill1T;
    public Text Skill2T;
    public Text AttackT;
    public Button Jump;
    public Button Crouch;
    public Button Left;
    public Button Right;
    public Button Rotate;
    public Button Skill1;
    public Button Skill2;
    public Button Attack;
    public Button BackB;
    public Button ResetB;
    private GameObject currentKey;
    /*public Text HudT;
    public Text HealthbarT;
    public Dropdown HudDD;
    public Dropdown HealthbarDD;*/

    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
    private Dictionary<string, int> ui = new Dictionary<string, int>();

    void Start()
    {
        BackB.onClick.AddListener(() => Back());
        ResetB.onClick.AddListener(() => Reset());

        if (Load() != 0)
        {
            keys.Add("Jump", KeyCode.W);
            keys.Add("Crouch", KeyCode.S);
            keys.Add("Left", KeyCode.A);
            keys.Add("Right", KeyCode.D);
            keys.Add("Swap", KeyCode.Space);
            keys.Add("Skill1", KeyCode.J);
            keys.Add("Skill2", KeyCode.K);
            keys.Add("Attack", KeyCode.L);
            //ui.Add(HudDD.ToString(), 0);
            //ui.Add(HealthbarDD.ToString(), 0);
            Save();
        }

        Jump.GetComponentInChildren<Text>().text = keys["Jump"].ToString();
        Crouch.GetComponentInChildren<Text>().text = keys["Crouch"].ToString();
        Left.GetComponentInChildren<Text>().text = keys["Left"].ToString();
        Right.GetComponentInChildren<Text>().text = keys["Right"].ToString();
        Rotate.GetComponentInChildren<Text>().text = keys["Swap"].ToString();
        Skill1.GetComponentInChildren<Text>().text = keys["Skill1"].ToString();
        Skill2.GetComponentInChildren<Text>().text = keys["Skill2"].ToString();
        Attack.GetComponentInChildren<Text>().text = keys["Attack"].ToString();
        //HudDD.value = ui[HudDD.ToString()];
        //HealthbarDD.value = ui[HealthbarDD.ToString()];

        //InputM.keys = this.keys;
    }

    void OnGUI()
    {
        if (currentKey != null)
        {
            Event e = Event.current;

            if (e.isKey)
            {
                keys[currentKey.name] = e.keyCode;
                currentKey.GetComponentInChildren<Text>().text = e.keyCode.ToString();
                Save();
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
        inputSettingsMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);
    }

    private void Reset()
    {
        keys["Jump"] = KeyCode.W;
        keys["Crouch"] = KeyCode.S;
        keys["Left"] = KeyCode.A;
        keys["Right"] = KeyCode.D;
        keys["Swap"] = KeyCode.Space;
        keys["Skill1"] = KeyCode.J;
        keys["Skill2"] = KeyCode.K;
        keys["Attack"] = KeyCode.L;
        //ui[HudDD.ToString()] = 0;
        //ui[HealthbarDD.ToString()] = 0;

        Save();

        Jump.GetComponentInChildren<Text>().text = keys["Jump"].ToString();
        Crouch.GetComponentInChildren<Text>().text = keys["Crouch"].ToString();
        Left.GetComponentInChildren<Text>().text = keys["Left"].ToString();
        Right.GetComponentInChildren<Text>().text = keys["Right"].ToString();
        Rotate.GetComponentInChildren<Text>().text = keys["Swap"].ToString();
        Skill1.GetComponentInChildren<Text>().text = keys["Skill1"].ToString();
        Skill2.GetComponentInChildren<Text>().text = keys["Skill2"].ToString();
        Attack.GetComponentInChildren<Text>().text = keys["Attack"].ToString();
        //HudDD.value = 0;
        //HealthbarDD.value = 0;
    }

    public void Dropdowns(Dropdown clicked)
    {
        ui[clicked.ToString()] = clicked.value;
        Save();
    }

    private void Save()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(GlobalVariable.keysFilepath);

        binaryFormatter.Serialize(file, keys);
        file.Close();

        file = File.Create(GlobalVariable.uiFilepath);
        binaryFormatter.Serialize(file, ui);
        file.Close();

        InputM.keys = this.keys;
        InputM.ui = this.ui;
    }

    private int Load()
    {
        int returnValue = 0;        // with every error increase it by 1, 2, 4, 8, 16... and so on

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file;

        if (CheckSaves(GlobalVariable.keysFilepath))
        {
            file = File.Open(GlobalVariable.keysFilepath, FileMode.Open);
            keys = (Dictionary<string, KeyCode>)binaryFormatter.Deserialize(file);
            file.Close();
        }
        else
        {
            returnValue += 1;
        }

        if (CheckSaves(GlobalVariable.uiFilepath))
        {
            file = File.Open(GlobalVariable.uiFilepath, FileMode.Open);
            ui = (Dictionary<string, int>)binaryFormatter.Deserialize(file);
            file.Close();
        }
        else
        {
            returnValue += 2;
        }

        return returnValue;
    }

    private bool CheckSaves(string filepath)
    {
        return File.Exists(filepath);
    }
}
