using UnityEngine;
using UnityEngine.UI;

public class MagicShield : ColorAbility
{
    public Image SecondSkillCoolDown;
    private Color defaultColor;
    private bool defaultDirection;

    public float timeLeft = 1.8f;

    private void Start()
    {
        findObjects();
        defaultColor = SecondSkillCoolDown.color;
        defaultDirection = SecondSkillCoolDown.fillClockwise;
    }

    void Update()
    {
        if (isAbilityReady())
        {
            timeLeft = 1.8f;
            if (isButtonDownProper() && isPositionProper())
            {
                animator.SetBool("IsShield", true);

                knight.SetMagicImmunity();
                mage.SetMagicImmunity();
                archer.SetMagicImmunity();

                SetAbilityColor();
                setCooldown();

                SecondSkillCoolDown.fillAmount = 1;
            }
        }

        else if (!isAbilityStillWorking() || !isPositionProper())
        {
            knight.DisableMagicImmunity();
            mage.DisableMagicImmunity();
            archer.DisableMagicImmunity();

            BackToNormalColor();
            reduceCooldown();

            //SecondSkillCoolDown.fillAmount = currentCooldown / cooldown;
        }

        timeLeft -= Time.deltaTime;
        if (timeLeft < 0 && animator.GetBool("IsShield"))
        {

            animator.SetBool("IsShield", false);
            timeLeft = 1.8f;
        }

        if (!isPositionProper())
            SecondSkillCoolDown.fillAmount = 1;
        else
            SecondSkillCoolDown.fillAmount = currentCooldown / cooldown;
    }
}