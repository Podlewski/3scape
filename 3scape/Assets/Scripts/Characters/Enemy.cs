using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public float startHealth;
    private float health;

    public float speed;
    public Image optionalHealthBar;
    public Transform characters;

    void Start () {
        health = startHealth;
    }
	
	void Update () {

        if(health <=0)
        {
            Destroy(gameObject);
        }

        if (Physics2D.Raycast(transform.position, Vector2.left, 7, 1 << 8 /*player layerMask*/)) {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if (Physics2D.Raycast(transform.position, Vector2.right, 7, 1 << 8 /*player layerMask*/))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (optionalHealthBar != null)
            optionalHealthBar.fillAmount = health / startHealth;

        Debug.Log(damage + " damage was taken!");
    }
}
