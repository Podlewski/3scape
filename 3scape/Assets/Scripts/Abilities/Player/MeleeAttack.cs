using UnityEngine;

public class MeleeAttack : PlayerAbility
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

            if (InputM.GetAxisRaw("Ability") == 8 && isPositionProper())
            //if (isButtonDownProper() == 8 && isPositionProper())
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

