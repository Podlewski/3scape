using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MorePPEffects;

public class KnightFasterWalking : ColorAbility
{
    CharacterController2D characterController2D;

    public Image SecondSkillCoolDown;
    private Color defaultColor;
    private bool defaultDirection;
    private RadialBlur effect;

    void Start()
    {
        findObjects();
        defaultColor = SecondSkillCoolDown.color;
        defaultDirection = SecondSkillCoolDown.fillClockwise;
        effect = FindObjectOfType<RadialBlur>();
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

                if (effect != null)
                    effect.enabled = true;
            }
        }
        else if (!isAbilityStillWorking() || !isPositionProper())
        {
            PlayerMovement.runSpeed = 20f;

            BackToNormalColor();
            reduceCooldown();

            //SecondSkillCoolDown.fillAmount = currentCooldown / cooldown;

            if (effect != null)
                effect.enabled = false;
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
