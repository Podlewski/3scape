using UnityEngine;
using UnityEngine.UI;

public class MagicShield : PlayerAbility
{
    private Player knight;
    private Player mage;
    private Player archer;

    private SpriteRenderer srKnight;
    private SpriteRenderer srMage;
    private SpriteRenderer srArcher;

    private Color32 playerColor = new Color32(255, 255, 255, 225);
    private Color32 healtColor = new Color32(19, 255, 0, 255);
    public Color32 magicColor = new Color32(0, 255, 216, 225);

    public Image SecondSkillCoolDown;

    private void Start()
    {
        knight = GameObject.Find("knight").GetComponent<Player>();
        mage = GameObject.Find("mage").GetComponent<Player>();
        archer = GameObject.Find("archer").GetComponent<Player>();

        srKnight = GameObject.Find("knight").GetComponent<SpriteRenderer>();
        srMage = GameObject.Find("mage").GetComponent<SpriteRenderer>();
        srArcher = GameObject.Find("archer").GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isAbilityReady())
        {
            if (isButtonDownProper() && isPositionProper())
            {
                knight.SetMagicImmunity();
                mage.SetMagicImmunity();
                archer.SetMagicImmunity();

                knight.healthBar.color = magicColor;
                mage.healthBar.color = magicColor;
                archer.healthBar.color = magicColor;

                srKnight.color = magicColor;
                srMage.color = magicColor;
                srArcher.color = magicColor;

                setCooldown();

                SecondSkillCoolDown.fillAmount = 1;
            }
        }

        else if (!isAbilityStillWorking() || !isPositionProper())
        {
            knight.DisableMagicImmunity();
            mage.DisableMagicImmunity();
            archer.DisableMagicImmunity();

            knight.healthBar.color = healtColor;
            mage.healthBar.color = healtColor;
            archer.healthBar.color = healtColor;

            srKnight.color = playerColor;
            srMage.color = playerColor;
            srArcher.color = playerColor;

            reduceCooldown();

            SecondSkillCoolDown.fillAmount = currentCooldown / cooldown;
        }

    }
}
