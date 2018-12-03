using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockingChests : PlayerAbility
{
    public float downTime, upTime, pressTime = 0;
    public float countDown = 2.0f;
    public bool ready = false;

    // public AudioClip attemptSound;
    public AudioSource source;

    public Transform unlockPos;
    public float unlockRange;
    public LayerMask whatCanOpen;

    public float timeAmt = 0.02f;
    float time;
    public bool tmp = false;

    public Image FirstSkillCoolDown;

    private void Start()
    {
        time = timeAmt;
    }

    void Update ()
    {
        if (isAbilityReady() && isPositionProper())
        {
            Collider2D[] col = Physics2D.OverlapCircleAll(unlockPos.position, unlockRange, whatCanOpen);

            //animator.SetBool("jakasAnimacja", false);
            if (isButtonPressedProper() && ready == false)
            {
                if (source != null)
                {
                    source.Play();
                }
                downTime = Time.time;
                pressTime = downTime + countDown;
                ready = true;
                tmp = true;
            }

            if (time > 0 && tmp == true)
            {
                time -= Time.deltaTime * 4.8f;
                for (int i = 0; i < col.Length; i++)
                {
                    if (col[i].tag == "Chest")
                    {
                        col[i].GetComponent<Chest>().timeBar.fillAmount = time / timeAmt;

                    }
                }
            }

            if (isButtonUpProper())
            {
                ready = false;
                tmp = false;
                time = timeAmt;
            }

            if (Time.time >= pressTime && ready == true && isPositionProper())
            {
                ready = false;
                //animator.SetBool("jakasAnimacja", true);

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

        if (!isPositionProper())
            FirstSkillCoolDown.fillAmount = 1;
        else
            FirstSkillCoolDown.fillAmount = 0;
    }
}
