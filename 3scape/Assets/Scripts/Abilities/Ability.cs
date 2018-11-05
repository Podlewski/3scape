using UnityEngine;

public class Ability : MonoBehaviour
{
    public Animator animator;
    public KeyCode abilityKey;
    public int requiredPosition;
    public float castTime;
    public float cooldown;
    protected float currentCooldown;

    protected bool isAbilityReady()
    {
        return currentCooldown <= 0;
    }

    protected void setCooldown()
    {
        currentCooldown = cooldown;
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
}
