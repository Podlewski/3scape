using UnityEngine;

public class Ability : MonoBehaviour
{
    public Animator animator;
    public KeyCode abilityKey;
    public int requiredPosition;
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

    protected bool isPressedKeyProper()
    {
        return Input.GetKeyDown(abilityKey);
    }

    protected bool isUpKeyProper()
    {
        return Input.GetKeyUp(abilityKey);
    }

    protected bool isPositionProper()
    {
        return animator.GetInteger("Position") == requiredPosition;
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
