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

    static InputM()
    {
        Load();
    }

    public static void SetKey(string keyMap, KeyCode key)
    {
        if(!keys.ContainsKey(keyMap))
        {
            throw new ArgumentException("Invalid KeyMap in SetKeyMap: " + keyMap);
        }

        keys[keyMap] = key;

        Save();
    }

    // True while = button held down
    public static bool GetButton(string buttonName)
    {
        return Input.GetButton(buttonName);
    }

    // True for frame = button pressed
    public static bool GetButtonDown(string buttonName)
    {
        return Input.GetButtonDown(buttonName);
    }

    // True for frame = button released
    public static bool GetButtonUp(string buttonName)
    {
        return Input.GetButtonUp(buttonName);
    }

    // True while = key held down; autofire
    public static bool GetKey(string name)
    {
        return Input.GetKey(name);
    }

    // True for frame = key pressed
    public static bool GetKeyDown(string keyMap)
    {
        return Input.GetKeyDown(keys[keyMap]);
    }

    // True for frame = key released
    public static bool GetKeyUp(string name)
    {
        return Input.GetKeyUp(keys[name]);
    }

    public static float GetAxisRaw(string axisName)
    {
        switch(axisName)
        {
            case "Horizontal":
                if (Input.GetKey(keys["Right"]))
                {
                    Debug.Log("Horizontal-Right-1");
                    return 1;
                }
                else if (Input.GetKey(keys["Left"]))
                {
                    Debug.Log("Horizontal-Left- -1");
                    return -1;
                }
                else
                {
                    return 0;
                }
                break;
            case "Vertical":
                if (Input.GetKeyDown(keys["Up"]))
                {
                    Debug.Log("Vertical-Up-1");
                    return 1;
                }
                else if (Input.GetKey(keys["Down"]))
                {
                    Debug.Log("Vertical-Down- -1");
                    return -1;
                }
                else
                {
                    return 0;
                }
                break;
            case "Ability":
                //Debug.Log("Ability-START");
                if (Input.GetKeyDown(keys["Swap"]))
                {
                    Debug.Log("Ability-Swap-1");
                    return 1;
                }
                else if (Input.GetKey(keys["Skill1"])) // J
                {
                    Debug.Log("Ability-Skill1-2");
                    return 2;
                }
                else if (Input.GetKey(keys["Skill2"])) // K
                {
                    Debug.Log("Ability-Skill2-4");
                    return 4;
                }
                else if (Input.GetKey(keys["Attack"])) // L
                {
                    Debug.Log("Ability-Attack-8");
                    return 8;
                }
                else
                {
                    Debug.Log("Ability-none-0");
                    return 0;
                }
                break;
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
