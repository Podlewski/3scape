using UnityEngine;

public class MeleeAttack : PlayerAbility
{
    public Transform attackPos;
    public LayerMask whatIsEnemy;
    public float attackRange;
    public int damage;

    public AudioClip swordSound;
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

