using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 20f;

    bool jump = false;
    bool crouch = false;

    float horizontalMove = 0f;  
	
	// Update is called once per frame
	void Update () {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
       // animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        crouch = Input.GetButton("Crouch");
	}

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
