using UnityEngine;

public class Ability : MonoBehaviour
{
    public float cooldown;
    protected float currentCooldown;

    public float duration;
    protected float remaindingDuration;

    protected bool isAbilityReady()
    {
        return currentCooldown <= 0;
    }

    protected void setCooldown()
    {
        currentCooldown = cooldown;
        remaindingDuration = duration;
    }

    protected void reduceCooldown()
    {
        currentCooldown -= Time.deltaTime;
    }

    protected bool isAbilityStillWorking()
    {
        if (remaindingDuration > 0)
        {
            remaindingDuration -= Time.deltaTime;
            return true;
        }

        else
            return false;
    }

}
