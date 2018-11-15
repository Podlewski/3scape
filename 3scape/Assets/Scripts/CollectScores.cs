using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectScores : MonoBehaviour
{
    private Scores scores;
    public GameObject itemButton;

    private void Start()
    {
        scores = GameObject.FindGameObjectWithTag("Player").GetComponent<Scores>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            for (int i = 0; i < scores.slots; i++)
            {
                Destroy(gameObject);
                scores.score++;
                break;
            }
        }
    }
}
