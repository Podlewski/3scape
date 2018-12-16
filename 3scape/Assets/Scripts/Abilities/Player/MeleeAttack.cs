using UnityEngine;

public class MeleeAttack : PlayerAbility
{
    public Transform attackPos;
    public LayerMask whatIsEnemy;
    public float attackRange;
    public int damage;

    public AudioClip swordSound;
    public AudioClip woodHitting;
    public AudioClip zombieHitting;
    public AudioSource source;

    void Update()
    {
        if (isAbilityReady())
        {
            animator.SetBool("IsAttacking", false);

            if (isButtonDownProper() && isPositionProper())
            {
                animator.SetBool("IsAttacking", true);
                source.PlayOneShot(swordSound);

                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
                foreach (var enemy in enemiesToDamage)
                {
                    if (enemy.gameObject.name.Equals("Barrel"))
                    {
                        source.Stop();
                        source.PlayOneShot(woodHitting);
                    }

                    if (enemy.gameObject.name.Equals("zombie"))
                    {
                        source.Stop();
                        AudioSource.PlayClipAtPoint(zombieHitting, enemy.gameObject.transform.position);
                    }

                    enemy.GetComponent<Enemy>().TakeDamage(damage);
                }

                setCooldown();
            }
        }

        else
            reduceCooldown();

    }
}

