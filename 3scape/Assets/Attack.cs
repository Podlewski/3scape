using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public float timeBtwAttack;
    public float startBtwAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemy;
    public float attackRange;
    public int damage;
	
	void Update () {
		
        if(timeBtwAttack <= 0)
        {
            //then you can attack
            if (Input.GetKey(KeyCode.LeftControl))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
                for(int i=0; i<enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
            }
            
            timeBtwAttack = startBtwAttack;
        }

        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
	}

    /*void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);

    }*/
}
