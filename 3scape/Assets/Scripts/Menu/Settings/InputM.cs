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

    public static bool GetKeyDown(string keyMap)
    {
        return Input.GetKeyDown(keys[keyMap]);
    }

    private static void Save()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(GlobalVariable.saveFilepath);

        binaryFormatter.Serialize(file, keys);
        file.Close();
    }

    private static void Load()
    {
        if(CheckSaves())
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Open(GlobalVariable.saveFilepath, FileMode.Open);

            keys = (Dictionary<string, KeyCode>)binaryFormatter.Deserialize(file);
            file.Close();
        }
    }

    private static bool CheckSaves(string filepath = GlobalVariable.saveFilepath)
    {
        return File.Exists(filepath);
    }
}
