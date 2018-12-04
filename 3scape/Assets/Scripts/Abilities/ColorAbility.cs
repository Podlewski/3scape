using UnityEngine;

public class ColorAbility : PlayerAbility
{
    protected Player knight;
    protected Player mage;
    protected Player archer;

    protected SpriteRenderer srKnight;
    protected SpriteRenderer srMage;
    protected SpriteRenderer srArcher;

    protected Color32 playerColor = new Color32(255, 255, 255, 225);
    protected Color32 healtColor = new Color32(19, 255, 0, 255);

    public Color32 abilityColor;

    protected bool needToSwapColor = false;

    protected void findObjects()
    {
        knight = GameObject.Find("knight").GetComponent<Player>();
        archer = GameObject.Find("archer").GetComponent<Player>();
        mage = GameObject.Find("mage").GetComponent<Player>();

        srKnight = GameObject.Find("knight").GetComponent<SpriteRenderer>();
        srArcher = GameObject.Find("archer").GetComponent<SpriteRenderer>();
        srMage = GameObject.Find("mage").GetComponent<SpriteRenderer>();
    }

    public void BackToNormalColor(bool changeKnight = true,
                                  bool changeArcher = true,
                                  bool changeMage = true)
    {
        if (needToSwapColor)
        {
            if (changeKnight)
            {
                srKnight.color = playerColor;
                knight.healthBar.color = healtColor;
            }

            if (changeArcher)
            {
                srArcher.color = playerColor;
                archer.healthBar.color = healtColor;
            }

            if (changeMage)
            {
                srMage.color = playerColor;
                mage.healthBar.color = healtColor;
            }

            needToSwapColor = false;
        }
    }

    public void SetAbilityColor(bool changeKnight = true,
                                bool changeArcher = true,
                                bool changeMage = true)
    {
        if (changeKnight)
        {
            srKnight.color = abilityColor;
            knight.healthBar.color = abilityColor;
        }

        if (changeArcher)
        {
            srArcher.color = abilityColor;
            archer.healthBar.color = abilityColor;
        }

        if (changeMage)
        {
            srMage.color = abilityColor;
            mage.healthBar.color = abilityColor;
        }

        needToSwapColor = true;
    }
}
