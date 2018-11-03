using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightFasterWalking : MonoBehaviour
{
    GameObject mage;
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
            /*Vector3 posistion = archer.transform.position;
            Debug.Log(archer.transform.position + " " + posistion.y);
            archer.transform.Translate(0,1,0);
            Debug.Log(archer.transform.position + " " + posistion.y);*/
            //mage.GetComponent<CircleCollider2D>().transform.Translate(0, -1, 0);
            
        }

        if (Input.GetKeyDown(KeyCode.M) && GlobalVariable.isKnightInMiddle)
        {
            PlayerMovement.runSpeed = 20f;
            pressed = false;
        }

        if (!GlobalVariable.isKnightInMiddle)
        {
            PlayerMovement.runSpeed = 20f;
        }
    }

}
