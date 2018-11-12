using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockingChests : Ability
{
    public float downTime, upTime, pressTime = 0;
    public float countDown = 2.0f;
    public bool ready = false;

    public Transform unlockPos;
    public float unlockRange;
    public LayerMask whatCanOpen;

	void Update ()
    {
        if (isAbilityReady())
        {
            //animator.SetBool("jakasAnimacja", false);
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
                    //animator.SetBool("jakasAnimacja", true);

                    Collider2D[] col = Physics2D.OverlapCircleAll(unlockPos.position, unlockRange, whatCanOpen);
                    Debug.Log(col.Length);

                    for (int i = 0; i < col.Length; i++)
                    {
                    if (col[i].tag == "Chest")
                        {
                        col[i].GetComponent<Chest>().checkIfOpen();
                            setCooldown();
                        }
                    }
                }
        }

        else
        {
            currentCooldown -= Time.deltaTime;
        }
    }
}
