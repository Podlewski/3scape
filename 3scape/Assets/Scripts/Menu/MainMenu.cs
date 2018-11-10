using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuUI;
    public Button ContinueB;
    public Button NewGameB;
    public Button SelectLevelB;
    public Button TutorialB;
    public Button OptionsB;
    public Button QuitB;

    void Start()
    {
        ContinueB.onClick.AddListener(() => Continue());
        NewGameB.onClick.AddListener(() => NewGame());
        SelectLevelB.onClick.AddListener(() => SelectLevelMenu());
        TutorialB.onClick.AddListener(() => StartTutorial());
        OptionsB.onClick.AddListener(() => Options());
        QuitB.onClick.AddListener(() => Quit());
    }

    void Update() { }

    private void Continue() { }

    private void NewGame()
    {
        //SceneManager.LoadScene("tutorial", LoadSceneMode.Single);
    }

    private void SelectLevelMenu()
    {
        SceneManager.LoadSceneAsync("select_level_menu", LoadSceneMode.Single);
    }

    private void StartTutorial()
    {
        SceneManager.LoadScene("tutorial", LoadSceneMode.Single);
    }

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
