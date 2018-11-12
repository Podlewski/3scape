using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightFasterWalking : Ability
{
    //GameObject mage;
    CharacterController2D characterController2D;
    bool pressed = false;

    // Use this for initialization
    void Start()
    {
        //mage = GameObject.Find("mage");
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressedKeyProper() && isPositionProper() && !pressed)
        {
            pressed = true;
            PlayerMovement.runSpeed = 50f;
            //mage.GetComponent<CircleCollider2D>().offset = new Vector2(0.1188198f, -0.5f);

        }
        else if((isUpKeyProper() && isPositionProper()) || (!isPositionProper()))
        {
            //mage.GetComponent<CircleCollider2D>().offset = new Vector2(0.1188198f, -0.29f);
            PlayerMovement.runSpeed = 20f;
            pressed = false;
        }
    }

}
