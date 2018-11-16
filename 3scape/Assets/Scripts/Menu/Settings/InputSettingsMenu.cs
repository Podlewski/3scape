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

    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    void Start()
    {
        BackB.onClick.AddListener(() => Back());
        ResetB.onClick.AddListener(() => Reset());

        if (!Load())
        {
            keys.Add("Jump", KeyCode.W);
            keys.Add("Crouch", KeyCode.S);
            keys.Add("Left", KeyCode.A);
            keys.Add("Right", KeyCode.D);
            keys.Add("Rotate", KeyCode.Space);
            keys.Add("Skill1", KeyCode.J);
            keys.Add("Skill2", KeyCode.K);
            keys.Add("Attack", KeyCode.L);
            Save();
        }

        Jump.GetComponentInChildren<Text>().text = keys["Jump"].ToString();
        Crouch.GetComponentInChildren<Text>().text = keys["Crouch"].ToString();
        Left.GetComponentInChildren<Text>().text = keys["Left"].ToString();
        Right.GetComponentInChildren<Text>().text = keys["Right"].ToString();
        Rotate.GetComponentInChildren<Text>().text = keys["Rotate"].ToString();
        Skill1.GetComponentInChildren<Text>().text = keys["Skill1"].ToString();
        Skill2.GetComponentInChildren<Text>().text = keys["Skill2"].ToString();
        Attack.GetComponentInChildren<Text>().text = keys["Attack"].ToString();

        //InputM.keys = this.keys;
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
                Save();
                currentKey = null;

                //foreach(var k in keys)
                //    Debug.Log(k.ToString());
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

    private void Reset()
    {
        keys["Jump"] = KeyCode.W;
        keys["Crouch"] = KeyCode.S;
        keys["Left"] = KeyCode.A;
        keys["Right"] = KeyCode.D;
        keys["Rotate"] = KeyCode.Space;
        keys["Skill1"] = KeyCode.J;
        keys["Skill2"] = KeyCode.K;
        keys["Attack"] = KeyCode.L;

        Save();

        Jump.GetComponentInChildren<Text>().text = keys["Jump"].ToString();
        Crouch.GetComponentInChildren<Text>().text = keys["Crouch"].ToString();
        Left.GetComponentInChildren<Text>().text = keys["Left"].ToString();
        Right.GetComponentInChildren<Text>().text = keys["Right"].ToString();
        Rotate.GetComponentInChildren<Text>().text = keys["Rotate"].ToString();
        Skill1.GetComponentInChildren<Text>().text = keys["Skill1"].ToString();
        Skill2.GetComponentInChildren<Text>().text = keys["Skill2"].ToString();
        Attack.GetComponentInChildren<Text>().text = keys["Attack"].ToString();
    }

    private void Save()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(GlobalVariable.saveFilepath);

        binaryFormatter.Serialize(file, keys);
        file.Close();

        InputM.keys = this.keys;
    }

    private bool Load()
    {
        if(CheckSaves())
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Open(GlobalVariable.saveFilepath, FileMode.Open);

            keys = (Dictionary<string, KeyCode>)binaryFormatter.Deserialize(file);
            file.Close();

            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CheckSaves(string filepath = GlobalVariable.saveFilepath)
    {
        return File.Exists(filepath);
    }
}
