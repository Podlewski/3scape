using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gamePaused = false;
    public GameObject pauseMenuUI;
    public Button ResumeB;
    public Button RestartB;
    public Button OptionsB;
    public Button MenuB;
    public Button QuitB;

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
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (gamePaused)
                Resume();
            else
                Pause();
        }
	}

    private void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gamePaused = false;
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gamePaused = true;
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Resume();
    }

    private void Options()
    {
        // TODO
        //SceneManager.LoadScene(SceneManager.GetSceneByName(/*options scene name*/));
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
