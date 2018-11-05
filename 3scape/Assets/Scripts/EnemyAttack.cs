using UnityEngine;

public class EnemyAttack : EnemyAbility
{
    public Transform attackPos;
    public LayerMask whatIsEnemy;
    public float attackRange;
    public int damage;

    void Update()
    {
        if (isAbilityReady())
        {
           // animator.SetBool("IsAttacking", true);

            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<Player>().TakeDamage(damage);
            }

            setCooldown();
            //animator.SetBool("IsAttacking", false);
        }

        else
        {
            currentCooldown -= Time.deltaTime;

        }

    }
}
