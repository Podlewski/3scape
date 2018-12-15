using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MusicSettingsMenu : MonoBehaviour
{
    public Button BackB;
    public Slider MasterS;

    private AudioSource volume;

    void Start()
    {
        BackB.onClick.AddListener(() => Back());
        MasterS.onValueChanged.AddListener(delegate { Master(); });

        volume = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    private void Back()
    {
        SceneManager.LoadSceneAsync("settings_menu", LoadSceneMode.Single);
    }

    private void Master()
    {
        volume.volume = MasterS.value;
    }
}
