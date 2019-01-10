using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour
{
    public static bool activeVictoryScreen = false;
    public GameObject victoryScreenUI;
    public Button NextLevelB;
    public Button RestartB;
    public Button MenuB;
    public Text ScoreT;

    public Player[] player;
    public GameObject playerAvgPos;
    public GameObject final;
    public string nextSceneName;

    private readonly int requiredProximity = 5;
    private Dictionary<Player, Vector3> startingCoords = new Dictionary<Player, Vector3>();
    private Vector3 startingAvgPos = new Vector3();

    private Score levelScore;

    void Start()
    {
        levelScore = GameObject.Find("Characters").GetComponent<Score>();
        NextLevelB.onClick.AddListener(() => NextLevel());
        RestartB.onClick.AddListener(() => Restart());
        MenuB.onClick.AddListener(() => Menu());

        foreach (var p in player)
            startingCoords.Add(p, p.GetComponent<Transform>().position);
        startingAvgPos = playerAvgPos.GetComponent<Transform>().position;
    }

    void Update()
    {
        if (NewLevel.levelFinished)
        {
            ActivateVictoryScreen();
        }
    }

    public void ActivateVictoryScreen()
    {
        ScoreT.text = "Score: " + levelScore.score;
        Time.timeScale = 0;
        victoryScreenUI.SetActive(true);
        PauseMenu.gamePaused = true;
        activeVictoryScreen = true;
    }

    private void DeactivateVictoryScreen()
    {
        NewLevel.levelFinished = false;
        victoryScreenUI.SetActive(false);
        RestartCharacters();
        PauseMenu.gamePaused = false;
        Time.timeScale = 1;
        activeVictoryScreen = false;
    }

    private void NextLevel()
    {
        DeactivateVictoryScreen();
        SceneManager.LoadScene(nextSceneName, LoadSceneMode.Single);
    }

    private void Restart()
    {
        DeactivateVictoryScreen();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Menu()
    {
        DeactivateVictoryScreen();
        SceneManager.LoadSceneAsync("main_menu", LoadSceneMode.Single);
    }

    private void RestartCharacters()
    {
        foreach (var p in player)
            p.health = p.startHealth;

        foreach (var p in player)
            if (p != null)
                p.GetComponent<Transform>().position = startingCoords[p];

        playerAvgPos.GetComponent<Transform>().position = startingAvgPos;
    }
}
