using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guide2 : MonoBehaviour
{
    public GameObject guide;
    private GameObject partyPosition;
    public float range = 5;
    public Text txt;

    public string text1;
    public string position;
    public string text2;
    public string keyCode;
    public string text3;

    // Use this for initialization
    void Start()
    {
        fillText();
        partyPosition = GameObject.Find("playerAvgPos");

        if (txt != null) txt.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (guide != null && partyPosition != null && range > 0 && txt != null)
        {
            float distance = Math.Abs(guide.transform.position.x - partyPosition.transform.position.x);
            if (distance < range)
            {
                //Debug.Log("triggered" + distance);
                txt.enabled = true;
                //txt.color = new Color(1, 1, 1, 0.5f);
            }
            else
            {
                txt.enabled = false;
            }
        }
    }

    void fillText()
    {
        txt.text = text1 + " " + position + " " + text2 + " " + keyCode + " " + text3;
    }
}