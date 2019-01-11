using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Credits : MonoBehaviour
{
    public Button BackToMenuB;
    private bool reset;

    void Start ()
    {
        reset = true;
        StartCoroutine(TimeCounter());
        BackToMenuB.onClick.AddListener(() => BackToMenu());
    }

    private void BackToMenu()
    {
        reset = false;
        SceneManager.LoadScene("main_menu", LoadSceneMode.Single);
    }

    private IEnumerator TimeCounter()
    {
        yield return new WaitForSeconds(22f);
        if (reset == true)
            BackToMenu();
    }

}
