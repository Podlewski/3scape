using UnityEngine.UI;
public class PhysicalShield : ColorAbility
{
    CharacterController2D characterController2D;
    public Image SecondSkillCoolDown;
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
                // SecondSkillCoolDown.fillAmount = 1;
            }
        }
        else if (!isAbilityStillWorking() || !isPositionProper())
        {
            PlayerMovement.runSpeed = 20f;
            knight.DisbalePhysicalImmunity();
            BackToNormalColor(true, false, false);
            reduceCooldown();
            // SecondSkillCoolDown.fillAmount = currentCooldown / cooldown;
        }

        //if (!isPositionProper())
        //    SecondSkillCoolDown.fillAmount = 1;
        //else
        //    SecondSkillCoolDown.fillAmount = currentCooldown / cooldown;
    }
}