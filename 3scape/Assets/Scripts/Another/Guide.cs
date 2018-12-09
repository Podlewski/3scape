using System;
using UnityEngine;
using UnityEngine.UI;

public class Guide : MonoBehaviour
{
    public GameObject guide;
    private GameObject partyPosition;
    public Text txt;
    public float range = 5;

    public enum keysDropdown
    {
        Empty,
        Up,
        Down,
        Left,
        Right,
        Swap,
        Skill1,
        Skill2,
        Attack
    };

    public bool smarterText = false;

    [TextArea]
    public string text1;
    public keysDropdown dropdown1;
    [TextArea]
    public string text2;
    public keysDropdown dropdown2;
    [TextArea]
    public string text3;

    // Use this for initialization
    void Start()
    {
        if (smarterText == true)
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
        if (dropdown1.ToString() == "Empty")
            txt.text = text1;

        else if (dropdown2.ToString() == "Empty")
            txt.text = text1 + " " + InputM.keys[dropdown1.ToString()] + " " + text2;

        else
            txt.text = text1 + " " + InputM.keys[dropdown1.ToString()] + " " + text2 + " " + InputM.keys[dropdown2.ToString()] + " " + text3;
    }
}