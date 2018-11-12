using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorns : EnemyAbility
{ 
    public Transform attackPos;
    public LayerMask whatIsEnemy;
    public float attackRange;
    public int damage;

	void Update ()
    {
        if (isAbilityReady())
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);

            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<Player>().TakeMagicDamage(damage);
                setCooldown();
            }
            
        }

        else
        {
            currentCooldown -= Time.deltaTime;

        }
    }
}
