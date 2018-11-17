using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gamePaused = false;
    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;
    public Button ResumeB;
    public Button RestartB;
    public Button OptionsB;
    public Button MenuB;
    public Button QuitB;

    public KeyCode pauseKeyCode;

    void Start()
    {
        ResumeB.onClick.AddListener(() => Resume());
        RestartB.onClick.AddListener(() => Restart());
        OptionsB.onClick.AddListener(() => Options());
        MenuB.onClick.AddListener(() => Menu());
        QuitB.onClick.AddListener(() => Quit());
    }

    void Update()
    {
        if (!DeathScreen.activeDeathScreen && Input.GetKeyDown(pauseKeyCode))
        {
            if (gamePaused)
                Resume();
            else
                Pause();
        }
	}

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        gamePaused = false;
        Time.timeScale = 1;
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenuUI.SetActive(true);
        gamePaused = true;
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Resume();
    }

    private void Options()
    {
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);
    }

    private void Menu()
    {
        SceneManager.LoadSceneAsync("main_menu", LoadSceneMode.Single);
        Resume();
    }

    private void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
