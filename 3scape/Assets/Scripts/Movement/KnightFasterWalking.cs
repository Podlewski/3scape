using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightFasterWalking : MonoBehaviour
{
    GameObject mage;
    CharacterController2D characterController2D;
    bool pressed = false;

    // Use this for initialization
    void Start()
    {
        mage = GameObject.Find("mage");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N) && GlobalVariable.isKnightInMiddle && !pressed)
        {
            pressed = true;

            PlayerMovement.runSpeed = 30f;
            mage.GetComponent<CircleCollider2D>().offset = new Vector2(0.1188198f, -0.5f);

        }

        if ((Input.GetKeyDown(KeyCode.M) && GlobalVariable.isKnightInMiddle) || (!GlobalVariable.isKnightInMiddle))
        {
            mage.GetComponent<CircleCollider2D>().offset = new Vector2(0.1188198f, -0.29f);
            PlayerMovement.runSpeed = 20f;
            pressed = false;
        }
    }

}
