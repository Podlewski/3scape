using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage;

	void Start () {
        rb.velocity = transform.right * speed;
	}

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);

        hitInfo.GetComponent<Enemy>().TakeDamage(damage);
        Destroy(gameObject);
    }
}
