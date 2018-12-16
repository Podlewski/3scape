using MorePPEffects;
using UnityEngine;
using UnityEngine.UI;

public class PhysicalShield : ColorAbility
{
    CharacterController2D characterController2D;

    public Image FirstSkillCoolDown;
    private Color defaultColor;
    private bool defaultDirection;
    private Colorization effect;

    void Start()
    {
        findObjects();
        defaultColor = FirstSkillCoolDown.color;
        defaultDirection = FirstSkillCoolDown.fillClockwise;
        effect = FindObjectOfType<Colorization>();
    }

    void Update()
    {
        if (isAbilityReady())
        {
            if (isButtonDownProper() && isPositionProper())
            {
                PlayerMovement.runSpeed = 10f;
                knight.SetPhysicalImmunity();
                SetAbilityColor(true, false, false);
                setCooldown();
                FirstSkillCoolDown.fillAmount = 1;

                if (effect != null)
                    effect.enabled = true;
            }
        }
        else if (!isAbilityStillWorking() || !isPositionProper())
        {
            PlayerMovement.runSpeed = 20f;
            knight.DisablePhysicalImmunity();
            BackToNormalColor(true, false, false);
            reduceCooldown();
            // FirstSkillCoolDown.fillAmount = currentCooldown / cooldown;

            if (effect != null)
                effect.enabled = false;
        }

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