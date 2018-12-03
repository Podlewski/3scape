using UnityEngine;
using UnityEngine.UI;
public class PhysicalShield : ColorAbility
{
    CharacterController2D characterController2D;

    public Image FirstSkillCoolDown;
    private Color defaultColor;
    private bool defaultDirection;

    void Start()
    {
        knight = GameObject.Find("knight").GetComponent<Player>();
        archer = GameObject.Find("archer").GetComponent<Player>();
        mage = GameObject.Find("mage").GetComponent<Player>();

        srKnight = GameObject.Find("knight").GetComponent<SpriteRenderer>();
        srArcher = GameObject.Find("archer").GetComponent<SpriteRenderer>();
        srMage = GameObject.Find("mage").GetComponent<SpriteRenderer>();

        defaultColor = FirstSkillCoolDown.color;
        defaultDirection = FirstSkillCoolDown.fillClockwise;
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
            }
        }
        else if (!isAbilityStillWorking() || !isPositionProper())
        {
            PlayerMovement.runSpeed = 20f;
            knight.DisbalePhysicalImmunity();
            BackToNormalColor(true, false, false);
            reduceCooldown();
            // FirstSkillCoolDown.fillAmount = currentCooldown / cooldown;
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