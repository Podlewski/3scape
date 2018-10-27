using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyingObstacles : Ability
{
    public Transform destroyPos;
    public LayerMask whatIsObstacle;
    public float destroyRange;
    public int damage;

    void Update()
    {
        if (isAbilityReady())
        {
            // jakies animacje nk

            if (isPressedKeyProper() && isPositionProper())
            {
                Collider2D[] obstaclesToDamage = Physics2D.OverlapCircleAll(destroyPos.position, destroyRange, whatIsObstacle);
                for (int i = 0; i < obstaclesToDamage.Length; i++)
                {
                    obstaclesToDamage[i].GetComponent<Obstacle>().DestroyObstacle(damage);
                }

                setCooldown();
            }
        }

        else
        {
            currentCooldown -= Time.deltaTime;

        }
    }
}

