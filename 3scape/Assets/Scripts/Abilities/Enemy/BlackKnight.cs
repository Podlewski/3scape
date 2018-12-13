using UnityEngine;

public class BlackKnight : AnimatedAbility
{
    public LayerMask whatIsEnemy;
    public float attackRange;
    public int damage;

    public AudioClip zombieSound;
    public AudioSource source;

    private bool start = true;

    void Start()
    {
        source.clip = zombieSound;
    }

    void Update()
    {
        if ((Physics2D.Raycast(transform.position, Vector2.left, attackRange, whatIsEnemy)
          || Physics2D.Raycast(transform.position, Vector2.right, attackRange, whatIsEnemy)))
        {
            animator.SetTrigger("IsAttacking");

            if (isAbilityReady())
            {
                setCooldown();

                if (!start)
                {
                    var enemiesToDamage = Physics2D.OverlapCircleAll(gameObject.transform.Find("AttackPoint").position, attackRange + 2.2f, 1 << 8);
                    foreach (var enemy in enemiesToDamage)
                    {
                        enemy.GetComponent<Player>().TakePhysicalDamage(damage);
                    }

                    source.Play();
                }
                else
                {
                    start = false;
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
            animator.ResetTrigger("IsAttacking");
        }

    }
}
