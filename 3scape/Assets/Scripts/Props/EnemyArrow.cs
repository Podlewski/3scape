using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrow : MonoBehaviour {

    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage;

    private float startTime;

    void Start()
    {
        startTime = Time.time;
        rb.velocity = -transform.right * speed;
    }

    void Update()
    {
        if (Time.time - startTime > 10)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name + " " + damage);

        if (hitInfo.GetComponent<Player>() != null)
        {
            hitInfo.GetComponent<Player>().TakeDamage(damage);
            Destroy(gameObject);
        }

    }
}
