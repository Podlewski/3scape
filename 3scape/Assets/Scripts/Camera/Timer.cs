using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {



    private float startingTime;
    private Text timerText;
	// Use this for initialization
	void Start () {
        timerText = GetComponent<Text>();
        startingTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
        startingTime += Time.deltaTime;

        timerText.text = "" + Mathf.Round(startingTime) + "s";
	}
}
