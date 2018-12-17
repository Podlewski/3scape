using UnityEngine;
using UnityEngine.UI;

public class MagicShield : ColorAbility
{
    public Image SecondSkillCoolDown;
    private Color defaultColor;
    private bool defaultDirection;
    public GameObject effect;

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

                effect.SetActive(true);
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

            //effect.SetActive(false);
        }

        timeLeft -= Time.deltaTime;
        if (timeLeft < 0 && animator.GetBool("IsShield"))
        {

            animator.SetBool("IsShield", false);
            timeLeft = 1.8f;
        }

        if (isAbilityStillWorking())
        {
            SecondSkillCoolDown.color = new Color(0.5f, 0.2f, 0.7f, 0.8f);
            SecondSkillCoolDown.fillClockwise = !defaultDirection;
            SecondSkillCoolDown.fillAmount = remaindingDuration / duration;
        }
        else
        {
            SecondSkillCoolDown.color = defaultColor;
            SecondSkillCoolDown.fillClockwise = defaultDirection;
            SecondSkillCoolDown.fillAmount = currentCooldown / cooldown;
        }

        if (!isPositionProper())
        {
            SecondSkillCoolDown.color = defaultColor;
            SecondSkillCoolDown.fillAmount = 1;
        }
        else if (!isAbilityStillWorking())
            SecondSkillCoolDown.fillAmount = currentCooldown / cooldown;
    }
}