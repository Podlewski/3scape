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
    private Text thirdSkillTextCdMage;
    private Text thirdSkillTextCdArcher;

    private bool mageFlag;
    private bool archerFlag;

    void Start()
    {
        thirdSkillTextCdMage = GameObject.Find("ThirdSkillTextCdMage").GetComponent<Text>();
        thirdSkillTextCdArcher = GameObject.Find("ThirdSkillTextCdArcher").GetComponent<Text>();
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

            int val = (int)currentCooldown;
            
            thirdSkillTextCdMage.text = val.ToString();
            if (currentCooldown < 0.1)
            {
                thirdSkillTextCdMage.text = "";
            }

            thirdSkillTextCdArcher.text = val.ToString();
            if (currentCooldown < 0.1)
            {
                thirdSkillTextCdArcher.text = "";
            }

            
        }

        if (!isPositionProper())
        {
            ThirdSkillCoolDown.color = defaultColor;
            ThirdSkillCoolDown.fillAmount = 1;
        }
        else if (!isAbilityStillWorking())
            ThirdSkillCoolDown.fillAmount = currentCooldown / cooldown;
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
