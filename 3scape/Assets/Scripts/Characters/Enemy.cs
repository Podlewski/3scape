using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public float startHealth;
    private float health;

    public float speed;
    public Image healthBar;
    //public Animator animator;

    void Start () {
        //animator.SetBool("IsAttacking", true);
        health = startHealth;
    }
	
	void Update () {

        if(health <=0)
        {
            Destroy(gameObject);
        }

        transform.Translate(Vector2.left * speed * Time.deltaTime);
	}

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.fillAmount = health / startHealth;
        Debug.Log(damage + " damage was taken!");
    }
}
