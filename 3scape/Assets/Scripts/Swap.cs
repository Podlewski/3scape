using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swap : MonoBehaviour
{
    public int position;
    Vector3 newPosition;

    public Animator animator;
    public float timeBtwSwap;
    public float swapTimer = 0.5f;

    bool blockSwap = false;

    void Update()
    {
        if (timeBtwSwap <= 0)
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (position == 1 && blockSwap == false)
                {
                    position = 2;
                    newPosition = transform.position;
                    newPosition.x -= 1;
                    transform.position = newPosition;

                    blockSwap = true;
                }

                if (position == 2 && blockSwap == false)
                {
                    position = 1;
                    newPosition = transform.position;
                    newPosition.x += 1;
                    transform.position = newPosition;

                    blockSwap = true;
                }

                blockSwap = false;
                timeBtwSwap = swapTimer;

            }

            if (Input.GetKey(KeyCode.Q))
            {
                if (position == 2 && blockSwap == false)
                {
                    position = 3;
                    newPosition = transform.position;
                    newPosition.x -= 1;
                    transform.position = newPosition;

                    blockSwap = true;
                }

                if (position == 3 && blockSwap == false)
                {
                    position = 2;
                    newPosition = transform.position;
                    newPosition.x += 1;
                    transform.position = newPosition;

                    blockSwap = true;
                }

                blockSwap = false;
                timeBtwSwap = swapTimer;
            }
        }

        else
        {
            timeBtwSwap -= Time.deltaTime;
        }
        animator.SetInteger("Position", position);
    }

}
