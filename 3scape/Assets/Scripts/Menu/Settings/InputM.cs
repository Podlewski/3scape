using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class InputM
{
    public static Dictionary<string, KeyCode> keys;
    public static Dictionary<string, int> ui;

    /// <summary>
    /// It is noteworthy that GetButton-like function won't really work as expected and
    /// they should not be used. It is strongly recommended to use GetKey-like functions only
    /// </summary>
    static InputM()
    {
        Load();
    }

    public static void SetKey(string keyMap, KeyCode key)
    {
        if (!keys.ContainsKey(keyMap))
            throw new ArgumentException("Invalid KeyMap in SetKeyMap: " + keyMap);

        keys[keyMap] = key;
        Save();
    }

    /// <summary>
    /// DEPRECATED
    /// True while = button held down
    /// </summary>
    /// <param name="buttonName"></param>
    /// <returns></returns>
    public static bool GetButton(string buttonName)
    {
        return Input.GetButton(buttonName);
    }

    /// <summary>
    /// DEPRECATED
    /// True for frame = button pressed
    /// </summary>
    /// <param name="buttonName"></param>
    /// <returns></returns>
    public static bool GetButtonDown(string buttonName)
    {
        return Input.GetButtonDown(buttonName);
    }

    /// <summary>
    /// DEPRECATED
    /// True for frame = button released
    /// </summary>
    /// <param name="buttonName"></param>
    /// <returns></returns>
    public static bool GetButtonUp(string buttonName)
    {
        return Input.GetButtonUp(buttonName);
    }

    /// <summary>
    /// True while = key held down; autofire
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static bool GetKey(string name)
    {
        return Input.GetKey(keys[name]);
    }

    /// <summary>
    /// True for frame = key pressed
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static bool GetKeyDown(string name)
    {
        return Input.GetKeyDown(keys[name]);
    }

    /// <summary>
    /// True for frame = key released
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static bool GetKeyUp(string name)
    {
        return Input.GetKeyUp(keys[name]);
    }

    /// <summary>
    /// Unlike GetKey-like functions GetAxis-like ones won't work with custom Input
    /// so here it is. And since we use only M+K setup ternary system is sufficient
    /// </summary>
    /// <param name="axisName"></param>
    /// <returns></returns>
    public static float GetAxisRaw(string axisName)
    {
        switch(axisName)
        {
            case "Horizontal":
                if (Input.GetKey(keys["Right"]))
                    return 1;
                else if (Input.GetKey(keys["Left"]))
                    return -1;
                else
                    return 0;
                break;
            case "Vertical":
                if (Input.GetKeyDown(keys["Up"]))
                    return 1;
                else if (Input.GetKey(keys["Down"]))
                    return -1;
                else
                    return 0;
                break;
            /*case "Ability":
                if (Input.GetKeyDown(keys["Swap"]))
                    return 1;
                else if (Input.GetKey(keys["Skill1"])) // J
                    return 2;
                else if (Input.GetKey(keys["Skill2"])) // K
                    return 4;
                else if (Input.GetKey(keys["Attack"])) // L
                    return 8;
                else
                    return 0;
                break;*/
            default:
                throw new ArgumentException();
        }
    }

    private static void Save()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(GlobalVariable.keysFilepath);

        binaryFormatter.Serialize(file, keys);
        file.Close();

        file = File.Create(GlobalVariable.uiFilepath);
        binaryFormatter.Serialize(file, ui);
        file.Close();
    }

    private static void Load()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file;

        if (CheckSaves(GlobalVariable.keysFilepath))
        {
            file = File.Open(GlobalVariable.keysFilepath, FileMode.Open);
            keys = (Dictionary<string, KeyCode>)binaryFormatter.Deserialize(file);
            file.Close();
        }

        if(CheckSaves(GlobalVariable.uiFilepath))
        {
            file = File.Open(GlobalVariable.uiFilepath, FileMode.Open);
            ui = (Dictionary<string, int>)binaryFormatter.Deserialize(file);
            file.Close();
        }
    }

    private static bool CheckSaves(string filepath)
    {
        return File.Exists(filepath);
    }
}
