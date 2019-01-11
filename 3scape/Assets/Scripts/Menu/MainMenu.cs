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
    public Button Level02SLB;
    public Button BackSLB;

    public GameObject optionsUI;
    public Button AudioVideoOB;
    public Button ControlsOB;
    public Button BackOB;

    public Button LogoB;
    public SpriteRenderer LogoS;
    public SpriteRenderer KnightS;
    private int counter;

    public Sprite LogoBlack;
    public Sprite LogoBlue;
    public Sprite LogoGold;
    public Sprite LogoGreen;
    public Sprite LogoRed;
    public Sprite KnightBlack;
    public Sprite KnightBlue;
    public Sprite KnightGold;
    public Sprite KnightGreen;
    public Sprite KnightRed;

    void Start()
    {
        NewGameB.onClick.AddListener(() => SelectLevelMenu());
        LoadGameB.onClick.AddListener(() => LoadGameMenu());
        OptionsB.onClick.AddListener(() => Options());
        CreditsB.onClick.AddListener(() => Credits());
        QuitB.onClick.AddListener(() => Quit());

        TutorialSLB.onClick.AddListener(() => SLTutorial());
        Level01SLB.onClick.AddListener(() => SLLevel01());
        //Level02SLB.onClick.AddListener(() => SLLevel02());
        BackSLB.onClick.AddListener(() => SLBack());

        AudioVideoOB.onClick.AddListener(() => OAudioVideo());
        ControlsOB.onClick.AddListener(() => OControls());
        BackOB.onClick.AddListener(() => OBack());

        counter = 0;
        LogoB.onClick.AddListener(() => LogoChange());
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
        optionsUI.gameObject.SetActive(true);
        mainMenuUI.gameObject.SetActive(false);
    }

    private void Credits()
    {
        SceneManager.LoadScene("credits", LoadSceneMode.Single);
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

    private void SLLevel02()
    {
        SceneManager.LoadSceneAsync("Level02", LoadSceneMode.Single);
    }

    private void SLBack()
    {
        mainMenuUI.gameObject.SetActive(true);
        selectLevelUI.gameObject.SetActive(false);
    }

    private void OAudioVideo()
    {
        SceneManager.LoadSceneAsync("audiovideo", LoadSceneMode.Single);
    }
    
    private void OControls()
    {
        SceneManager.LoadSceneAsync("controls", LoadSceneMode.Single);
    }

    private void OBack()
    {
        mainMenuUI.gameObject.SetActive(true);
        optionsUI.gameObject.SetActive(false);
    }


    // Logo & Knight
    private void LogoChange()
    {
        counter++;

        if (counter >= 5)
            counter = 0;

        switch(counter)
        {
            case 0:
                LogoS.sprite = LogoBlack;
                KnightS.sprite = KnightBlack;
                break;
            case 1:
                LogoS.sprite = LogoBlue;
                KnightS.sprite = KnightBlue;
                break;
            case 2:
                LogoS.sprite = LogoGold;
                KnightS.sprite = KnightGold;
                break;
            case 3:
                LogoS.sprite = LogoGreen;
                KnightS.sprite = KnightGreen;
                break;
            case 4:
                LogoS.sprite = LogoRed;
                KnightS.sprite = KnightRed;
                break;
        }

    }

}
