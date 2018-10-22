using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingThroughWalls : MonoBehaviour {

    //public KeyCode immaterial;
    //public KeyCode material;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKeyDown(KeyCode.N) && GlobalVariable.isMageInMiddle)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<BoxCollider2D>().isTrigger = true;
            GetComponent<CircleCollider2D>().isTrigger = true;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .5f);
        }

        if(Input.GetKeyDown (KeyCode.M) && GlobalVariable.isMageInMiddle)
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
            GetComponent<BoxCollider2D>().isTrigger = false;
            GetComponent<CircleCollider2D>().isTrigger = false;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
	}
}
