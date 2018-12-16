using UnityEngine;

public class ZombieAttack : AnimatedAbility
{
    public LayerMask whatIsEnemy;
    public float attackRange;
    public int damage;

   // public AudioClip zombieSound;
   // public AudioSource source;

    void Update()
    {
        if ((Physics2D.Raycast(transform.position, Vector2.left, attackRange, whatIsEnemy /*player layerMask*/)
          || Physics2D.Raycast(transform.position, Vector2.right, attackRange, whatIsEnemy/*player layerMask*/)))
        {
            animator.SetBool("IsAttacking", true);
            if (isAbilityReady())
            {
                setCooldown();
                var enemiesToDamage = Physics2D.OverlapCircleAll(gameObject.transform.Find("AttackPoint").position, attackRange, 1 << 8);
                foreach (var enemy in enemiesToDamage)
                {
                    enemy.GetComponent<Player>().TakePhysicalDamage(damage);
                }
            }
            else
            {
                currentCooldown -= Time.deltaTime;
            }

        }

        else
        {
            currentCooldown -= Time.deltaTime;
            animator.SetBool("IsAttacking", false);
        }

    }
}
