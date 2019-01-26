using UnityEngine;
using UnityEngine.UI;

public class MeleeAttack : PlayerAbility
{
    public Transform attackPos;
    public LayerMask whatIsEnemy;
    public float attackRange;
    public int damage;

    public Image ThirdSkillCoolDown;
    private Color defaultColor;
    private bool defaultDirection;

    public AudioClip swordSound;
    public AudioClip woodHitting;
    public AudioClip zombieHitting;
    public AudioSource source;

    private Image skillImage;
    public Sprite skillSprite;
    public Sprite skillSpriteUsed;

    void Start()
    {
        skillImage = GameObject.Find("ThirdSkillKnightTrol").GetComponent<Image>();
        defaultColor = ThirdSkillCoolDown.color;
        defaultDirection = ThirdSkillCoolDown.fillClockwise;
    }

    void FixedUpdate()
    {
        if (isAbilityReady())
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    void Update()
    {
        if (isAbilityReady() && isPositionProper())
        {
            skillImage.sprite = skillSprite;
            if (isButtonPressedProper() && isPositionProper())
            //if (isButtonDownProper() && isPositionProper())
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

                ThirdSkillCoolDown.fillAmount = 1;
            }
        }
        else
        {
            reduceCooldown();
        }

        if (!isAbilityStillWorking())
        {
            skillImage.sprite = skillSprite;
        }

        if (!isPositionProper())
        {
            skillImage.sprite = skillSpriteUsed;
            //ThirdSkillCoolDown.color = defaultColor;
            //ThirdSkillCoolDown.fillAmount = 1;
        }
        else if (!isAbilityStillWorking())
        {
            ThirdSkillCoolDown.fillAmount = currentCooldown / cooldown;
        }
    }
}
