using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnightFasterWalking : PlayerAbility
{
    CharacterController2D characterController2D;

    private Player knight;
    private Player mage;
    private Player archer;

    private SpriteRenderer srKnight;
    private SpriteRenderer srMage;
    private SpriteRenderer srArcher;

    private Color32 playerColor = new Color32(255, 255, 255, 225);
    private Color32 healtColor = new Color32(19, 255, 0, 255);
    public Color32 fastColor = new Color32(255, 0, 80, 225);

    public Image SecondSkillCoolDown;

    // Use this for initialization
    void Start()
    {
        knight = GameObject.Find("knight").GetComponent<Player>();
        mage = GameObject.Find("mage").GetComponent<Player>();
        archer = GameObject.Find("archer").GetComponent<Player>();

        srKnight = GameObject.Find("knight").GetComponent<SpriteRenderer>();
        srMage = GameObject.Find("mage").GetComponent<SpriteRenderer>();
        srArcher = GameObject.Find("archer").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAbilityReady())
        {
            if (isButtonDownProper() && isPositionProper())
            {
                PlayerMovement.runSpeed = 50f;

                knight.healthBar.color = fastColor;
                mage.healthBar.color = fastColor;
                archer.healthBar.color = fastColor;

                srKnight.color = fastColor;
                srMage.color = fastColor;
                srArcher.color = fastColor;

                setCooldown();

                SecondSkillCoolDown.fillAmount = 1;
            }
        }

        else if (!isAbilityStillWorking() || !isPositionProper())
        {
            PlayerMovement.runSpeed = 20f;

            knight.healthBar.color = healtColor;
            mage.healthBar.color = healtColor;
            archer.healthBar.color = healtColor;

            srKnight.color = playerColor;
            srMage.color = playerColor;
            srArcher.color = playerColor;

            reduceCooldown();

            SecondSkillCoolDown.fillAmount = currentCooldown / cooldown;
        }

        if (!isPositionProper())
            SecondSkillCoolDown.fillAmount = 1;
        else
            SecondSkillCoolDown.fillAmount = currentCooldown / cooldown;
    }

}
