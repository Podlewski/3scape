using UnityEngine;

public class ZombieAttack : AnimatedAbility
{
    public LayerMask whatIsEnemy;
    public float attackRange;
    public int damage;

    public AudioClip zombieSound;
    public AudioSource source;

    void Start()
    {
        source.clip = zombieSound;
    }

    void Update()
    {
        if (isAbilityReady())
        {
            // animator.SetBool("IsAttacking", true);


            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(gameObject.transform.Find("AttackPoint").position, attackRange, whatIsEnemy);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<Player>().TakeMagicDamage(damage);
                source.Play();
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
