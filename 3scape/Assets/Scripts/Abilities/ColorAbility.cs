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

    void Start()
    {
        knight = GameObject.Find("knight").GetComponent<Player>();
        mage = GameObject.Find("mage").GetComponent<Player>();
        archer = GameObject.Find("archer").GetComponent<Player>();

        srKnight = GameObject.Find("knight").GetComponent<SpriteRenderer>();
        srMage = GameObject.Find("mage").GetComponent<SpriteRenderer>();
        srArcher = GameObject.Find("archer").GetComponent<SpriteRenderer>();
    }

    public void BackToNormalColor()
    {
        if (needToSwapColor)
        {
            Debug.Log("Back to normal color");

            srKnight.color = playerColor;
            srMage.color = playerColor;
            srArcher.color = playerColor;

            knight.healthBar.color = healtColor;
            mage.healthBar.color = healtColor;
            archer.healthBar.color = healtColor;

            needToSwapColor = false;
        }
    }

    public void SetAbilityColor()
    {
        Debug.Log("Trying to swap to: " + abilityColor);

        srKnight.color = abilityColor;
        srMage.color = abilityColor;
        srArcher.color = abilityColor;

        knight.healthBar.color = abilityColor;
        mage.healthBar.color = abilityColor;
        archer.healthBar.color = abilityColor;

        needToSwapColor = true;
    }
}
