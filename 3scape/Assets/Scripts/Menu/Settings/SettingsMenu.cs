using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Button AudioVideoB;
    public Button ControlsB;
    public Button IngameB;
    public Button BackB;

    void Start()
    {
        AudioVideoB.onClick.AddListener(() => AudioVideo());
        ControlsB.onClick.AddListener(() => Controls());
        IngameB.onClick.AddListener(() => Ingame());
        BackB.onClick.AddListener(() => Back());
    }

    //void Update() { }

    private void AudioVideo()
    {
        SceneManager.LoadSceneAsync("audiovideo_settings_menu", LoadSceneMode.Single);
    }

    private void Controls()
    {
        SceneManager.LoadSceneAsync("input_settings_menu", LoadSceneMode.Single);
    }

    public void Ingame()
    {
        SceneManager.LoadSceneAsync("ingame_settings_menu", LoadSceneMode.Single);
    }

    private void Back()
    {
        SceneManager.LoadSceneAsync("main_menu", LoadSceneMode.Single);
    }
}
