using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{

    public float startHealth = 1;
    private float health;
    //public Image healthBar;
    //public GameObject loadingScreen;
    //public Slider slider;

    void Start()
    {
        health = startHealth;
    }

    void Update()
    {
        //slider.value = health;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void DestroyObstacle(float damage)
    {
        health -= damage;
        //healthBar.fillAmount = health / startHealth;
        Debug.Log("damage taken!");
    }
}
