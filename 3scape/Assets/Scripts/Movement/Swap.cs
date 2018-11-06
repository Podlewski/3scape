using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swap : MonoBehaviour
{
    public int position;

    public Animator animator;
    public GameObject first;
    public GameObject second;
    public float swapTimer = 0.5f;

    void Update()
    {
        if (GlobalVariable.swapCooldown <= 0)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                if (position == 1)
                {
                    position = 2;
                    if (first.GetComponent<Animator>().GetInteger("Position") == 2)
                    {
                        var tmp = transform.position;
                        transform.position = first.transform.position;
                        first.transform.position = tmp;
                        first.GetComponent<Animator>().SetInteger("Position", 1);
                    }
                    else if (second.GetComponent<Animator>().GetInteger("Position") == 2)
                    {
                        var tmp = transform.position;
                        transform.position = second.transform.position;
                        second.transform.position = tmp;
                        second.GetComponent<Animator>().SetInteger("Position", 1);
                    }
                }

                GlobalVariable.swapCooldown = swapTimer;

            }

            if (Input.GetKey(KeyCode.E))
            {
                if (position == 2)
                {
                    position = 3;
                    if (first.GetComponent<Animator>().GetInteger("Position") == 3)
                    {
                        var tmp = transform.position;
                        transform.position = first.transform.position;
                        first.transform.position = tmp;
                        first.GetComponent<Animator>().SetInteger("Position", 2);
                    }
                    else if (second.GetComponent<Animator>().GetInteger("Position") == 3)
                    {
                        var tmp = transform.position;
                        transform.position = second.transform.position;
                        second.transform.position = tmp;
                        second.GetComponent<Animator>().SetInteger("Position", 2);
                    }
                }

                GlobalVariable.swapCooldown = swapTimer;
            }
        }

        else
        {
            if (GlobalVariable.swapCooldown > -1)
                GlobalVariable.swapCooldown -= Time.deltaTime;
        }
        animator.SetInteger("Position", position);
    }
    private void LateUpdate()
    {

    }
}
