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

    private void Start()
    {
        source.clip = swordSound;
    }

    void Update()
    {
        if (isAbilityReady())
        {
            animator.SetBool("IsAttacking", false);

            if (isButtonDownProper() && isPositionProper())
            {
                animator.SetBool("IsAttacking", true);
                source.Play();

                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
                foreach (var enemy in enemiesToDamage)
                {
                    if (enemiesToDamage[i].gameObject.name.Equals("Barrel"))
                    {
                        source.Stop();
                        source.PlayOneShot(woodHitting);
                    }

                    if (enemiesToDamage[i].gameObject.name.Equals("zombie"))
                    {
                        source.Stop();
                        AudioSource.PlayClipAtPoint(zombieHitting, enemiesToDamage[i].gameObject.transform.position);
                    }

                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }

                setCooldown();
            }
        }

        else
            reduceCooldown();

    }
}

