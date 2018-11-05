using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;
    public Animator animator;

    private int position = 1;
    public float distance = 3;
    public static float runSpeed = 20f;

    bool jump = false;
    bool crouch = false;

    float horizontalMove = 0f;

    void Start()
    {
        PositionChecker();
    }

    // Update is called once per frame
    void Update () {

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
    {
        PositionChecker();
    }

    void PositionChecker()
    {
        position = animator.GetInteger("Position");
        if (position == 1)
        {
            GlobalVariable.first = transform;
        }
        else if (position == 2)
        {
            GlobalVariable.second = transform;
        }
        else
        {
            GlobalVariable.third = transform;
        }
        float dst = Vector3.Distance(GlobalVariable.second.position, transform.position);
        if (dst > distance)
        {
            Vector3 vect = GlobalVariable.second.position - transform.position;
            vect = vect.normalized;
            vect *= (dst - distance);
            transform.position += vect;
        }
    }

}
