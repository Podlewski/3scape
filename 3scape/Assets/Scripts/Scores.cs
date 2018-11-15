using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour {

    public float slots = 100;

    public Text levelScore;
    public int score = 0;

    private void Update()
    {
        levelScore.text = score.ToString();
    }
}
