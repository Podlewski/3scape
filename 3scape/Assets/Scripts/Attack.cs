using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public Animator animator;

    public float timeBtwAttack;
    public float attackTimer = 1f;

    public Transform attackPos;
    public LayerMask whatIsEnemy;
    public float attackRange;
    public int damage;

    void Update()
    {



        if (timeBtwAttack <= 0)
        {
            animator.SetBool("IsAttacking", false);

            //then you can attack
            if (Input.GetKey(KeyCode.K) && animator.GetInteger("Position") == 1)
            {
                animator.SetBool("IsAttacking", true);
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
                timeBtwAttack = attackTimer;
            }

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

