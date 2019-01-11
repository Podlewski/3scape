using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioVideoSettingsMenu : MonoBehaviour
{
    public Button BackB;
    public Button ResetB;
    public Slider MasterS;
    public Slider MusicS;
    public Slider SfxS;

    private Dictionary<string, float> sound = new Dictionary<string, float>();

    void Start()
    {
        BackB.onClick.AddListener(() => Back());
        ResetB.onClick.AddListener(() => Reset());
        MasterS.onValueChanged.AddListener(delegate { ChangeVolume("Master", MasterS); });
        MusicS.onValueChanged.AddListener(delegate { ChangeVolume("Music", MusicS); });
        SfxS.onValueChanged.AddListener(delegate { ChangeVolume("Sfx", SfxS); });

        if (Load() != 0)
        {
            sound.Add("Master", 1);
            sound.Add("Music", 1);
            sound.Add("Sfx", 1);
            Save();
        }

        MasterS.value = sound["Master"];
        MusicS.value = sound["Music"];
        SfxS.value = sound["Sfx"];
    }

    private void Back()
    {
        SceneManager.LoadSceneAsync("main_menu", LoadSceneMode.Single);
    }

    private void ChangeVolume(string key, Slider slider)
    {
        sound[key] = slider.value;
        Save();
    }

    private void Reset()
    {
        sound["Master"] = 1;
        sound["Music"] = 1;
        sound["Sfx"] = 1;

        Save();

        MasterS.value = sound["Master"];
        MusicS.value = sound["Music"];
        SfxS.value = sound["Sfx"];
    }

    private void Save()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(GlobalVariable.soundFilepath);

        binaryFormatter.Serialize(file, sound);
        file.Close();

        InputM.sound = this.sound;
    }

    private int Load()
    {
        int returnValue = 0;

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file;

        if (CheckSaves(GlobalVariable.soundFilepath))
        {
            file = File.Open(GlobalVariable.soundFilepath, FileMode.Open);
            sound = (Dictionary<string, float>)binaryFormatter.Deserialize(file);
            file.Close();
        }
        else
        {
            returnValue += 4;
        }

        Debug.Log(returnValue);
        return returnValue;
    }

    private bool CheckSaves(string filepath)
    {
        return File.Exists(filepath);
    }
}
