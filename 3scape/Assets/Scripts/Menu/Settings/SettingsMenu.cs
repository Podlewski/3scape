using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Button AudioVideoB;
    public Button ControlsB;
    public Button BackB;

    void Start()
    {
        AudioVideoB.onClick.AddListener(() => AudioVideo());
        ControlsB.onClick.AddListener(() => Controls());
        BackB.onClick.AddListener(() => Back());
    }

    //void Update() { }

    private void AudioVideo() { }

    private void Controls()
    {
        SceneManager.LoadSceneAsync("input_settings_menu", LoadSceneMode.Single);
    }

    private void Back()
    {
        SceneManager.LoadSceneAsync("main_menu", LoadSceneMode.Single);
    }
}
