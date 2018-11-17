using UnityEngine;

public class Heal : Ability
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

            if (isPressedKeyProper() && isPositionProper())
            {
                animator.SetBool("IsHealing", true);

                knight.isBeingHealed = true;
                archer.isBeingHealed = true;
                mage.isBeingHealed = true;

                knight.Heal(healValue);
                archer.Heal(healValue);
                mage.Heal(healValue);
                //animator.SetBool("IsUsing", false);
                setCooldown();
            }
        }
        else
        {
            currentCooldown -= Time.deltaTime;
        }

        if (knight.isBeingHealed) knight.HealAnimation();
        if (mage.isBeingHealed) mage.HealAnimation();
        if (archer.isBeingHealed) archer.HealAnimation();
    }
}
