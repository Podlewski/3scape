using UnityEngine;
using UnityEngine.UI;

public class RangedAttack : PlayerAbility
{
    public Transform firePoint;
    public GameObject arrowPrefab;

    public Image ThirdSkillCoolDown;
    private Color defaultColor;
    private bool defaultDirection;

    public AudioClip shot;
    public AudioSource source;


    void Start()
    {
        defaultColor = ThirdSkillCoolDown.color;
        defaultDirection = ThirdSkillCoolDown.fillClockwise;
    }

    void Update()
    {
        if (isAbilityReady())
        {
            animator.SetBool("IsAttacking", false);

            //if (isButtonPressedProper() && isPositionProper())
            if (isButtonDownProper() && isPositionProper())
            {
                animator.SetBool("IsAttacking", true);

                Shoot();
                setCooldown();

                ThirdSkillCoolDown.fillAmount = 1;
            }
        }
        else
        {
            reduceCooldown(); 
        }
        

        if (!isPositionProper())
        {
            ThirdSkillCoolDown.color = defaultColor;
            ThirdSkillCoolDown.fillAmount = 1;
        }
        else if (!isAbilityStillWorking())
        {
            ThirdSkillCoolDown.fillAmount = currentCooldown / cooldown;
        }
            
	}

    void Shoot()
    {
        Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        if(source != null && shot != null)
        {
            source.PlayOneShot(shot);
        }
    }
}
