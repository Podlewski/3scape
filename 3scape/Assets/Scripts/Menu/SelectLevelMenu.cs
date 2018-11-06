using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectLevelMenu : MonoBehaviour
{
    public GameObject selectLevelUI;
    public Button BackB;
    public Button[] LevelsB = new Button[1];

    void Start()
    {
        BackB.onClick.AddListener(() => Back());
        LevelsB[0].onClick.AddListener(() => Select("tutorial")); // with proper scene naming these can be assigned in a loop
    }

    //void Update() { }

    private void Back()
    {
        SceneManager.LoadSceneAsync("main_menu", LoadSceneMode.Single);
    }

    private void Select(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
