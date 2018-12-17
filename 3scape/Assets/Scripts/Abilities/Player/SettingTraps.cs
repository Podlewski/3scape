﻿using UnityEngine;
using UnityEngine.UI;

public class SettingTraps : PlayerAbility
{
    public GameObject trap;
    public Transform settingPoint;

    public Image FirstSkillCoolDown;
    private Color defaultColor;
    private bool defaultDirection;

    public byte maxNumberOfTraps = 3;

    void Start()
    {
        defaultColor = FirstSkillCoolDown.color;
        defaultDirection = FirstSkillCoolDown.fillClockwise;
    }

    void Update ()
    {
        if (isAbilityReady() && isPositionProper() && isButtonPressedProper())
        {
            SetTrap();
            setCooldown();

            FirstSkillCoolDown.fillAmount = 1;
        }

        if(!isPositionProper() || !isAbilityStillWorking())
        {
            reduceCooldown();
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
        {
            FirstSkillCoolDown.color = defaultColor;
            FirstSkillCoolDown.fillAmount = 1;
        }
        else if (!isAbilityStillWorking())
            FirstSkillCoolDown.fillAmount = currentCooldown / cooldown;
    }

    void SetTrap()
    {

        Vector3 v3 = settingPoint.position;
        Instantiate(trap, v3, settingPoint.rotation);

        if(GlobalVariable.numberOfTraps < maxNumberOfTraps)
        {
            Instantiate(trap, settingPoint.position, settingPoint.rotation);
            GlobalVariable.numberOfTraps++;
        }

    }
}
