using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public float startHealth;
    private float health;

    public float speed;
    public Image optionalHealthBar;

    bool m_FacingLeft = true;
    void Start()
    {
        health = startHealth;
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        if (GetComponent<Animator>() != null)
        {
            if (!(Physics2D.Raycast(transform.position, Vector2.left, 0.3f, 1 << 8 /*player layerMask*/)
                           || (Physics2D.Raycast(transform.position, Vector2.right, 0.3f, 1 << 8 /*player layerMask*/))))
            {
                GetComponent<Animator>().SetFloat("Speed", speed);
                if (Physics2D.Raycast(transform.position, Vector2.left, 7, 1 << 8 /*player layerMask*/))
                {
                    if (!m_FacingLeft)
                        Flip();
                    m_FacingLeft = true;
                    transform.Translate(Vector2.left * speed * Time.deltaTime);

                }
                if (Physics2D.Raycast(transform.position, Vector2.right, 7, 1 << 8 /*player layerMask*/))
                {
                    Flip();
                    transform.Translate(Vector2.left * speed * Time.deltaTime);
                }
            }
            else
            {
                GetComponent<Animator>().SetFloat("Speed", 0);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (optionalHealthBar != null)
            optionalHealthBar.fillAmount = health / startHealth;

        Debug.Log(damage + " damage was taken!");
    }

    void Flip()
    {
        if (m_FacingLeft)
        {
            transform.Rotate(0f, 180f, 0f);
            m_FacingLeft = false;
        }
    }
}
