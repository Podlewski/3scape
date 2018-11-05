using UnityEngine;

public class EnemyAbility : MonoBehaviour
{
    public Animator animator;
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

}