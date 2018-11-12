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

    private readonly int allowedDistance = 20;
    private Dictionary<Player, Vector3> startingCoords = new Dictionary<Player, Vector3>();

    void Start()
    {
        RestartB.onClick.AddListener(() => Restart());
        MenuB.onClick.AddListener(() => Menu());

        foreach (var p in player)
            startingCoords.Add(p, p.GetComponent<Transform>().position);
    }

    void Update()
    {
        foreach (var p in player)
            if (!activeDeathScreen && p.health <= 0)
                ActivateDeathScreen();

        foreach(var p1 in player)
        {
            foreach (var p2 in player)
                if(p1 != null && p2 != null)
                    if (Mathf.Sqrt(Mathf.Pow(p1.GetComponent<Transform>().position.x - p2.GetComponent<Transform>().position.x, 2) + Mathf.Pow(p1.GetComponent<Transform>().position.y - p2.GetComponent<Transform>().position.y, 2)) > allowedDistance)
                        ActivateDeathScreen();
        }
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

    private void RestartCharacters()    // this function needs to restore starting setup of parameters used to determine if DeathScreen should be activated,
    {                                   // otherwise this script will activate DeathScreen and/or pause game before they change themselves after Restart
        foreach (var p in player)
            p.health = p.startHealth;

        foreach (var p in player)
            if (p != null)
                p.GetComponent<Transform>().position = startingCoords[p];
    }
}
