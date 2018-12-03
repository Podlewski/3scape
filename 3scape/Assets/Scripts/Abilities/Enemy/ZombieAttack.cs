using UnityEngine;

public class ZombieAttack : AnimatedAbility
{
    public LayerMask whatIsEnemy;
    public float attackRange;
    public int damage;

    void Update()
    {
        if ((Physics2D.Raycast(transform.position, Vector2.left, 0.7f, 1 << 8 /*player layerMask*/)
          || Physics2D.Raycast(transform.position, Vector2.right, 0.7f, 1 << 8 /*player layerMask*/)))
        {
            animator.SetBool("IsAttacking", true);
            if (isAbilityReady())
            {
                setCooldown();
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(gameObject.transform.Find("AttackPoint").position, attackRange, whatIsEnemy);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Player>().TakeMagicDamage(damage);
                }
            }

        }

        else
        {
            currentCooldown -= Time.deltaTime;
            animator.SetBool("IsAttacking", false);
        }

    }
}
