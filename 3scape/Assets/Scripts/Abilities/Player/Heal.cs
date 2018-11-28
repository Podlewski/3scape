using UnityEngine;
using UnityEngine.UI;

public class Heal : PlayerAbility
{
    public int healValue;

    private Player knight;
    private Player mage;
    private Player archer;

    public Image FirstSkillCoolDown;

    private void Start()
    {
        knight = GameObject.Find("knight").GetComponent<Player>();
        mage = GameObject.Find("mage").GetComponent<Player>();
        archer = GameObject.Find("archer").GetComponent<Player>();
    }

    void Update()
    {
        animator.SetBool("IsHealing", false);
        if (isAbilityReady())
        {
            //animator.SetBool("IsUsing", true);

            if (isButtonDownProper() == 2 && isPositionProper())
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

            FirstSkillCoolDown.fillAmount = currentCooldown / cooldown;
        }

        if (knight.isBeingHealed) knight.HealAnimation();
        if (mage.isBeingHealed) mage.HealAnimation();
        if (archer.isBeingHealed) archer.HealAnimation();

        if (!isPositionProper())
            FirstSkillCoolDown.fillAmount = 1;
        else
            FirstSkillCoolDown.fillAmount = currentCooldown / cooldown;
    }
}
