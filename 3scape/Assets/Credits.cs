using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public Button BackToMenuB;

    void Start ()
    {
        BackToMenuB.onClick.AddListener(() => BackToMenu());
    }

    private void BackToMenu()
    {
        SceneManager.LoadScene("main_menu", LoadSceneMode.Single);
    }
}
