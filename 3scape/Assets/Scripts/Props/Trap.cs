using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject explosion;

    public Transform trapPos;
    public LayerMask whatIsEnemy;
    public float explosionRange;
    public int damage;

    private bool triggered = false;
	
	// Update is called once per frame
	void Update () {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(trapPos.position, explosionRange, whatIsEnemy);

        if (!triggered && enemiesToDamage.Length > 0 )
        {
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                Debug.Log(i);
                triggered = true;
                //Instantiate(explosion, trapPos.position);
                Destroy(gameObject);
                enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
            }
  
        }
    }
}
