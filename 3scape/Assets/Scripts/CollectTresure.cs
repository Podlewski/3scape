using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectTresure : MonoBehaviour
{
    private Score levelScore;
    public GameObject itemButton;
    public int tresureValue;
    private Text valueText;

    private void Start()
    {
        levelScore = GameObject.Find("Characters").GetComponent<Score>();
        valueText.text = "+ " + tresureValue.ToString();
        valueText.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(LateCall()); 
        }
    }

    IEnumerator LateCall()
    {
        gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        valueText.enabled = true;

        yield return new WaitForSeconds(0.5f);

        levelScore.score += tresureValue;
        Destroy(gameObject);
    }


}
