using UnityEngine;

public class MeleeAttack : Ability
{
    public Transform attackPos;
    public LayerMask whatIsEnemy;
    public float attackRange;
    public int damage;

    void Update()
    {
        if (isAbilityReady())
        {
            animator.SetBool("IsAttacking", false);

            if (isPressedKeyProper() && isPositionProper())
            {
                animator.SetBool("IsAttacking", true);

                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }

                setCooldown();
            }
        }

        else
            reduceCooldown();

    }
}

