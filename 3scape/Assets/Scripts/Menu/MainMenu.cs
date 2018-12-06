using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuUI;
    public Button NewGameB;
    public Button LoadGameB;
    public Button OptionsB;
    public Button CreditsB;
    public Button QuitB;

    public GameObject selectLevelUI;
    public Button TutorialSLB;
    public Button Level01SLB;
    public Button BackSLB;

    void Start()
    {
        NewGameB.onClick.AddListener(() => SelectLevelMenu());
        LoadGameB.onClick.AddListener(() => LoadGameMenu());
        OptionsB.onClick.AddListener(() => Options());
        CreditsB.onClick.AddListener(() => Credits());
        QuitB.onClick.AddListener(() => Quit());

        TutorialSLB.onClick.AddListener(() => SLTutorial());
        Level01SLB.onClick.AddListener(() => SLLevel01());
        BackSLB.onClick.AddListener(() => SLBack());
    }

    // Main Menu

    private void SelectLevelMenu()
    {
        selectLevelUI.gameObject.SetActive(true);
        mainMenuUI.gameObject.SetActive(false);
    }

    private void LoadGameMenu()
    {
        //SceneManager.LoadSceneAsync("load_game_menu", LoadSceneMode.Single);
    }

    private void Options()
    {
        SceneManager.LoadScene("settings_menu", LoadSceneMode.Single);
    }

    private void Credits()
    {
        //SceneManager.LoadScene("credits_menu", LoadSceneMode.Single);
    }

    private void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    // Select Level

    private void SLTutorial()
    {
        SceneManager.LoadSceneAsync("Tutorial", LoadSceneMode.Single);
    }

    private void SLLevel01()
    {
        SceneManager.LoadSceneAsync("Level01", LoadSceneMode.Single);
    }

    private void SLBack()
    {
        mainMenuUI.gameObject.SetActive(true);
        selectLevelUI.gameObject.SetActive(false);
    }


}
