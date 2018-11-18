using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectTresure : MonoBehaviour
{
    private Score levelScore;
    public GameObject itemButton;
    public int tresureValue;

    private void Start()
    {
        levelScore = GameObject.Find("Characters").GetComponent<Score>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            levelScore.score += tresureValue;
            Destroy(gameObject);
        }
    }
}
