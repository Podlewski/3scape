﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewLevel : MonoBehaviour {

    public string levelName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !(GameObject.Find("black_knight") != null))
        {
            SceneManager.LoadScene(levelName);
        }
    }
}
