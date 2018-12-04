using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guide : MonoBehaviour
{
    public GameObject guide;
    private GameObject partyPosition;
    public float range = 5;
    public Text txt;

    // Use this for initialization
    void Start()
    {
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
}