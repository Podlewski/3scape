using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenuPauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;
    public GameObject inputSettingsMenuUI;
    public GameObject audioVideoSettingsMenuUI;
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

    private void AudioVideo()
    {
        settingsMenuUI.SetActive(false);
        audioVideoSettingsMenuUI.SetActive(true);
    }

    private void Controls()
    {
        settingsMenuUI.SetActive(false);
        inputSettingsMenuUI.SetActive(true);
    }

    private void Back()
    {
        settingsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }
}
