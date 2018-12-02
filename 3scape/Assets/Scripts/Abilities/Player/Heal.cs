using UnityEngine;
using UnityEngine.UI;

public class Heal : PlayerAbility
{
    public int healValue;

    private Player knight;
    private Player mage;
    private Player archer;

    public Image FirstSkillCoolDown;
    private Color defaultColor;
    private bool defaultDirection;

    private void Start()
    {
        knight = GameObject.Find("knight").GetComponent<Player>();
        mage = GameObject.Find("mage").GetComponent<Player>();
        archer = GameObject.Find("archer").GetComponent<Player>();

        defaultColor = FirstSkillCoolDown.color;
        defaultDirection = FirstSkillCoolDown.fillClockwise;
    }

    void Update()
    {
        animator.SetBool("IsHealing", false);
        if (isAbilityReady())
        {
            //animator.SetBool("IsUsing", true);

            if (isButtonDownProper() && isPositionProper())
            {
                animator.SetBool("IsHealing", true);

                knight.isBeingHealed = true;
                archer.isBeingHealed = true;
                mage.isBeingHealed = true;

                mage.Heal(healValue);
                archer.Heal(healValue);
                knight.Heal(healValue);
                //animator.SetBool("IsUsing", false);

                setCooldown();

                FirstSkillCoolDown.fillAmount = 1;
            }
        }
        else if (!isAbilityStillWorking() || !isPositionProper())
        {
            reduceCooldown();

            //FirstSkillCoolDown.fillAmount = currentCooldown / cooldown;
        }

        if (knight.isBeingHealed) knight.HealAnimation();
        if (mage.isBeingHealed) mage.HealAnimation();
        if (archer.isBeingHealed) archer.HealAnimation();

        if (isAbilityStillWorking())
        {
            FirstSkillCoolDown.color = new Color(0.5f, 0.2f, 0.7f, 0.8f);
            FirstSkillCoolDown.fillClockwise = !defaultDirection;
            FirstSkillCoolDown.fillAmount = remaindingDuration / duration;
        }
        else
        {
            FirstSkillCoolDown.color = defaultColor;
            FirstSkillCoolDown.fillClockwise = defaultDirection;
            FirstSkillCoolDown.fillAmount = currentCooldown / cooldown;
        }

        if (!isPositionProper())
            FirstSkillCoolDown.fillAmount = 1;
        else if (!isAbilityStillWorking())
            FirstSkillCoolDown.fillAmount = currentCooldown / cooldown;
    }
}
