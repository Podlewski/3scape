using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IngameSettingsMenu : MonoBehaviour
{
   // public Button BackB;
    public Button ResetB;
    public Text HudT;
    public Text HealthbarT;
    public Dropdown HudDD;
    public Dropdown HealthbarDD;

    //private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
    private Dictionary<string, int> ui = new Dictionary<string, int>();

    void Start()
    {
       // BackB.onClick.AddListener(() => Back());
        ResetB.onClick.AddListener(() => Reset());
        HudDD.onValueChanged.AddListener(delegate { Dropdowns("HudDD"); });
        HealthbarDD.onValueChanged.AddListener(delegate { Dropdowns("HealthbarDD"); });

        if (Load() != 0)
        {
            ui.Add("HudDD", 0);
            ui.Add("HealthbarDD", 0);

            Save();
        }

        HudDD.value = ui["HudDD"];
        HealthbarDD.value = ui["HealthbarDD"];
    }

    //private void Back()
    //{
    //    SceneManager.LoadSceneAsync("settings_menu", LoadSceneMode.Single);
    //}

    private void Reset()
    {
        ui["HudDD"] = 0;
        ui["HealthbarDD"] = 0;

        Save();

        HudDD.value = 0;
        HealthbarDD.value = 0;
    }

    private void Dropdowns(string key)
    {
        if (key == "HudDD")
            ui["HudDD"] = HudDD.value;
        else if (key == "HealthbarDD")
            ui["HealthbarDD"] = HealthbarDD.value;

        Save();
    }

    private void Save()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(GlobalVariable.uiFilepath);
        binaryFormatter.Serialize(file, ui);
        file.Close();

        InputM.ui = this.ui;
    }

    private int Load()
    {
        int returnValue = 0;

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file;

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

        Debug.Log(returnValue);
        return returnValue;
    }

    private bool CheckSaves(string filepath)
    {
        return File.Exists(filepath);
    }
}
