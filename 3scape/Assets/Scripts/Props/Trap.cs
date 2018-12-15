using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject explosion;

    public LayerMask whatIsEnemy;
    public float explosionRange;
    public int damage;

    private bool triggered = false;
	
	// Update is called once per frame
	void Update () {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(gameObject.transform.position, explosionRange, whatIsEnemy);

        if (!triggered && enemiesToDamage.Length > 0 )
        {
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                Debug.Log(i);
                triggered = true;
                Vector3 vector3 = gameObject.transform.position;
                vector3.y += 0.8f;
                Instantiate(explosion, vector3, transform.rotation = Quaternion.identity);
                Destroy(gameObject);
                GlobalVariable.numberOfTraps--;
                enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
            }
  
        }
    }
}
