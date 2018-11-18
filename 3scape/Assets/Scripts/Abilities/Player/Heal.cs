using UnityEngine;
using UnityEngine.UI;

public class Heal : PlayerAbility
{
    public int healValue;

    private Player knight;
    private Player mage;
    private Player archer;

    private SpriteRenderer srKnight;
    private SpriteRenderer srMage;
    private SpriteRenderer srArcher;

    private Color32 playerColor = new Color32(255, 255, 255, 225);
    public Color32 magicColor = new Color32(255, 18, 234, 14);

    public Image FirstSkillCoolDown;

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
        animator.SetBool("IsHealing", false);
        if (isAbilityReady())
        {
            //animator.SetBool("IsUsing", true);

            if (isButtonDownProper() && isPositionProper())
            {
                animator.SetBool("IsHealing", true);

                srKnight.color = magicColor;
                srMage.color = magicColor;
                srArcher.color = magicColor;


                knight.isBeingHealed = true;
                archer.isBeingHealed = true;
                mage.isBeingHealed = true;

                knight.Heal(healValue);
                archer.Heal(healValue);
                mage.Heal(healValue);
                //animator.SetBool("IsUsing", false);

                setCooldown();

                FirstSkillCoolDown.fillAmount = 1;
            }
        }
        else if (!isAbilityStillWorking() || !isPositionProper())
        {
            srKnight.color = playerColor;
            srMage.color = playerColor;
            srArcher.color = playerColor;
            reduceCooldown();

            FirstSkillCoolDown.fillAmount = currentCooldown / cooldown;
        }

        if (knight.isBeingHealed) knight.HealAnimation();
        if (mage.isBeingHealed) mage.HealAnimation();
        if (archer.isBeingHealed) archer.HealAnimation();
    }
}
