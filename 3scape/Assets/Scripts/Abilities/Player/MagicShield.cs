using UnityEngine;
using UnityEngine.UI;

public class MagicShield : ColorAbility
{
    public Image SecondSkillCoolDown;

    void Update()
    {
        if (isAbilityReady())
        {
            if (isButtonDownProper() && isPositionProper())
            {
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

            SecondSkillCoolDown.fillAmount = currentCooldown / cooldown;
        }

        if(!isPositionProper())
            SecondSkillCoolDown.fillAmount = 1;
        else
            SecondSkillCoolDown.fillAmount = currentCooldown / cooldown;
    }
}
