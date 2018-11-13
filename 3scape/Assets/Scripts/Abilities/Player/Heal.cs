﻿using UnityEngine;

public class Heal : PlayerAbility
{
    public int healValue;

    private Player knight;
    private Player mage;
    private Player archer;

    private void Start()
    {
        knight = GameObject.Find("knight").GetComponent<Player>();
        mage = GameObject.Find("mage").GetComponent<Player>();
        archer = GameObject.Find("archer").GetComponent<Player>();
    }

    void Update()
    {
        animator.SetBool("IsHealing", false);
        if (isAbilityReady())
        {
            //animator.SetBool("IsUsing", true);

            if (isButtonDownProper() && isPositionProper())
            {
                animator.SetBool("IsHealing", true);

                knight.Heal(healValue);
                archer.Heal(healValue);
                mage.Heal(healValue);

                //animator.SetBool("IsUsing", false);

                setCooldown();
            }
        }

        else
            reduceCooldown();

    }
}
