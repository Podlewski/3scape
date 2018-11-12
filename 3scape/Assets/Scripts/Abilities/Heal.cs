using UnityEngine;

public class Heal : Ability
{
    public Player knight;
    public Player mage;
    public Player archer;
    

    void Update()
    {
        animator.SetBool("IsHealing", false);
        if (isAbilityReady())
        {

            //animator.SetBool("IsUsing", true);

            if (isPressedKeyProper() && isPositionProper())
            {
                animator.SetBool("IsHealing", true);
                
                knight.Heal(5);
                archer.Heal(5);
                mage.Heal(5);
                //animator.SetBool("IsUsing", false);
                setCooldown();
            }
        }

        else
        {
            currentCooldown -= Time.deltaTime;
        }

    }
}
