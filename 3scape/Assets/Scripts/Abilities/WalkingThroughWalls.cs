using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingThroughWalls : MonoBehaviour {

    //public KeyCode immaterial;
    //public KeyCode material;
    bool isMageInviible = false;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {


        if (Input.GetKeyDown(KeyCode.K) && GlobalVariable.isMageInMiddle && isMageInviible == false)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<CapsuleCollider2D>().isTrigger = true;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .5f);

            isMageInviible = true;
        }
        else if(Input.GetKeyDown(KeyCode.K) && GlobalVariable.isMageInMiddle && isMageInviible == true)
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
            GetComponent<CapsuleCollider2D>().isTrigger = false;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);

            isMageInviible = false;
        }
	}
}
