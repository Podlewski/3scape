using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuUI;
    public Button StartB;
    public Button SelectLevelB;
    public Button OptionsB;
    public Button QuitB;

    void Start()
    {
        StartB.onClick.AddListener(() => StartGame());
        SelectLevelB.onClick.AddListener(() => SelectLevel());
        OptionsB.onClick.AddListener(() => Options());
        QuitB.onClick.AddListener(() => Quit());
    }

    void Update() { }

    private void StartGame()
    {
        SceneManager.LoadScene("tutorial", LoadSceneMode.Single);
    }

    private void SelectLevel() { }

    private void Options() { }

    private void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
