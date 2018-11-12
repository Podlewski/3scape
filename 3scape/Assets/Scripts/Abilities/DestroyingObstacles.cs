using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyingObstacles : Ability
{
    public Transform destroyPos;
    public LayerMask whatIsObstacle;
    public float destroyRange;
    public float damage;

    //Variables for measuring time of key hold down
    public float downTime, upTime, pressTime = 0;
    public float countDown = 2.0f;
    public bool ready = false;
    private float delay = 50f;

    void Update()
    {
        if (isAbilityReady())
        {
            // jakies animacje nk

            if (isPressedKeyProper() && ready == false)
            {
                downTime = Time.time;
                pressTime = downTime + countDown;
                ready = true;
            }

            if (isUpKeyProper())
            {
                ready = false;
            }

            if (Time.time >= pressTime && ready == true && isPositionProper())
            {
                ready = false;

                //while (delay > 0)
                //{
                    Collider2D[] obstaclesToDamage = Physics2D.OverlapCircleAll(destroyPos.position, destroyRange, whatIsObstacle);
                    for (int i = 0; i < obstaclesToDamage.Length; i++)
                    {
                        obstaclesToDamage[i].GetComponent<Obstacle>().DestroyObstacle(damage);
                        setCooldown();
                    }


                   // delay -= Time.deltaTime;
                //}
            }
        }

        else
        {
            currentCooldown -= Time.deltaTime;
            delay = 50f;
        }
    }
}
