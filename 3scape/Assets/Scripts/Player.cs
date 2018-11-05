using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public float startHealth;
    private float health;
    public Image healthBar;

    // Use this for initialization
    void Start () {
        health = startHealth;
    }
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.fillAmount = health / startHealth;
        Debug.Log(damage + " damage was taken!");
    }
}
