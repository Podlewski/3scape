using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;
    public Animator animator;

    private Transform leader;
    public float followSharpness = 1.0f;
    private int position = 1;
    Vector3 _followOffset;

    public static float runSpeed = 20f;

    bool jump = false;
    bool crouch = false;

    float horizontalMove = 0f;

    void Start()
    {
        CheckPosition(animator.GetInteger("Position"));
        // Cache the initial offset at time of load/spawn:
        _followOffset = transform.position - leader.position;
    }

    // Update is called once per frame
    void Update () {
        position = animator.GetInteger("Position");
        CheckPosition(position);
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("Jump", true);
            animator.SetBool("IsGrounded", controller.GetGrounded());
        }
        crouch = Input.GetButton("Crouch");


    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        animator.SetBool("Jump", false);
        animator.SetBool("IsGrounded", controller.GetGrounded());
    }
    void LateUpdate()
    {/*
        CheckPosition(position);
        // Apply that offset to get a target position.
        Vector3 targetPosition = leader.position + _followOffset;

        // Keep our y position unchanged.
        targetPosition.y = transform.position.y;

        // Smooth follow.    
        transform.position += (targetPosition - transform.position) * followSharpness ;*/
    }

    void CheckPosition(int pos)
    {
        if (pos == 1)
        {
            GlobalVariable.leader = transform;
            leader = transform;
        }
        else if (pos == 2)
        {
            GlobalVariable.middle = transform;
            leader = GlobalVariable.leader;
        }
        else
        {
            leader = GlobalVariable.middle;
        }
    }
}
