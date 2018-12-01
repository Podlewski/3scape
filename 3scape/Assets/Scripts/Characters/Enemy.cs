using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public float startHealth;
    private float health;

    public float speed;
    public Image optionalHealthBar;
    //public Animator animator;

    public AudioClip barrelSound;
    public AudioSource source;


    void Start () {
        //animator.SetBool("IsAttacking", true);
        health = startHealth;
        source.clip = barrelSound;
    }
	
	void Update () {

        if(health <=0)
        {
            
                if (gameObject.tag=="Barrel")
                {
                    source.Play();
                }

            
            Destroy(gameObject);
           
        }

        transform.Translate(Vector2.left * speed * Time.deltaTime);
	}

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (optionalHealthBar != null)
            optionalHealthBar.fillAmount = health / startHealth;

        Debug.Log(damage + " damage was taken!");
    }
}
