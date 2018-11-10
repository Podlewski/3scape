using System.Collections;
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

    bool jump = false;
    bool crouch = false;

    float horizontalMove = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        x = transform.position.x;
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
    }

}
