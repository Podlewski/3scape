using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    public static bool activeDeathScreen = false;
    public GameObject deathScreenUI;
    public Button RestartB;
    public Button MenuB;
    public Player[] player;

    void Start()
    {
        RestartB.onClick.AddListener(() => Restart());
        MenuB.onClick.AddListener(() => Menu());
    }

    void Update()
    {
        foreach (var p in player)
            if (!activeDeathScreen && p.health <= 0)
                ActivateDeathScreen();
    }

    public void ActivateDeathScreen()
    {
        Time.timeScale = 0;
        deathScreenUI.SetActive(true);
        PauseMenu.gamePaused = true;
        activeDeathScreen = true;
    }

    private void DeactivateDeathScreen()
    {
        deathScreenUI.SetActive(false);
        RestartCharacters();
        PauseMenu.gamePaused = false;
        Time.timeScale = 1;
        activeDeathScreen = false;
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        DeactivateDeathScreen();
    }

    private void Menu()
    {
        SceneManager.LoadSceneAsync("main_menu", LoadSceneMode.Single);
        DeactivateDeathScreen();
    }

    private void RestartCharacters()
    {
        foreach (var p in player)
            p.health = p.startHealth;
    }
}
