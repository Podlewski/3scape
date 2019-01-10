using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewLevel : MonoBehaviour
{
    public static bool levelFinished = false;
    //public string levelName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //SceneManager.LoadScene(levelName);
            levelFinished = true;
            //Debug.Log("NewLevel : OnTriggerEnter2D : " + levelFinished);
        }
    }
}
