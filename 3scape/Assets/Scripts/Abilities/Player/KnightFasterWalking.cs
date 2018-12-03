using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnightFasterWalking : ColorAbility
{
    CharacterController2D characterController2D;

    public Image SecondSkillCoolDown;

    void Update()
    {
        if (isAbilityReady())
        {
            if (isButtonDownProper() && isPositionProper())
            {
                PlayerMovement.runSpeed = 50f;

                SetAbilityColor();

                setCooldown();

                SecondSkillCoolDown.fillAmount = 1;
            }
        }

        else if (!isAbilityStillWorking() || !isPositionProper())
        {
            PlayerMovement.runSpeed = 20f;

            BackToNormalColor();

            reduceCooldown();

            SecondSkillCoolDown.fillAmount = currentCooldown / cooldown;
        }

        if (!isPositionProper())
            SecondSkillCoolDown.fillAmount = 1;
        else
            SecondSkillCoolDown.fillAmount = currentCooldown / cooldown;
    }

}
