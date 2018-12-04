using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnightFasterWalking : ColorAbility
{
    CharacterController2D characterController2D;

    public Image SecondSkillCoolDown;
    private Color defaultColor;
    private bool defaultDirection;

    void Start()
    {
        findObjects();
        defaultColor = SecondSkillCoolDown.color;
        defaultDirection = SecondSkillCoolDown.fillClockwise;
    }

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

            //SecondSkillCoolDown.fillAmount = currentCooldown / cooldown;
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
            SecondSkillCoolDown.fillAmount = 1;
        else if (!isAbilityStillWorking())
            SecondSkillCoolDown.fillAmount = currentCooldown / cooldown;
    }

}
