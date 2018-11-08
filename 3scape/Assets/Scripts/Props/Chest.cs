using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour{

    public SpriteRenderer spriteRenderer;
    public Sprite openSprite;
    private bool isOpen = false;

    public float downTime, upTime, pressTime = 0;
    public float countDown = 2.0f;
    public bool ready = false;

    public Transform unlockPos;
    public float unlockRange;
    public LayerMask whoCanOpen;

    public void Update()
    {
        Collider2D[] col = Physics2D.OverlapCircleAll(unlockPos.position, unlockRange, whoCanOpen);

        for (int i = 0; i <col.Length; i++)
        {
            if (col[i].tag == "Player")
            {
                if (Input.GetKeyDown(KeyCode.L) && ready == false)
                {
                    Debug.Log("1");
                    downTime = Time.time;
                    pressTime = downTime + countDown;
                    ready = true;
                }

                if (Input.GetKeyUp(KeyCode.L))
                {
                    Debug.Log("2");
                    ready = false;
                }

                if (Time.time >= pressTime && ready == true)
                {
                    ready = false;
                    Debug.Log("checking");

                    if (isOpen)
                    {
                        Debug.Log("opened");
                    }

                    else
                    {
                        Debug.Log("opening");
                        isOpen = true;
                        spriteRenderer.sprite = openSprite;
                    }
                }
            }
        }
    }
}
