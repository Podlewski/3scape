﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    private Animator animator;
    public int position = 1;
    public float distance = 3;
    public static float runSpeed = 20f;
    public float x;

   // public AudioClip jumpSound;
   // public AudioSource source;

    bool jump = false;
    bool crouch = false;

    bool direction = false; //right

    float horizontalMove = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
       // source.clip = jumpSound;
    }

    // Update is called once per frame
    void Update()
    {
        x = transform.position.x;
        horizontalMove = InputM.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        //if (InputM.GetAxisRaw("Vertical") == 1)
        if (Input.GetKeyDown(InputM.keys["Up"]))
        {
            jump = true;
           // source.Play();
            animator.SetBool("Jump", true);
            animator.SetBool("IsGrounded", controller.GetGrounded());
        }
        //crouch = InputM.GetAxisRaw("Vertical") == -1 ? true : false;
        crouch = Input.GetKey(InputM.keys["Down"]);

        //if (Input.GetKeyDown(KeyCode.A)) GlobalVariable.direction = true;
        //else if (Input.GetKeyDown(KeyCode.D)) GlobalVariable.direction = false;

        if (InputM.GetKeyDown("Left"))
            GlobalVariable.direction = true;
        else if (InputM.GetKeyDown("Right"))
            GlobalVariable.direction = false;
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        animator.SetBool("Jump", false);
        animator.SetBool("IsGrounded", controller.GetGrounded());
    }

    void LateUpdate()
    {}
}
