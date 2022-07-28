using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float speedX;
    public float jumpForce;
    private bool faceRight = true;

    private Rigidbody2D rb;
    private Animator anim;
    private GroundCheck groundCheck;

    private void MoveHorizontal()
    {
        transform.Translate(speedX, 0, 0);
    }

    private void Reflect()
    {
        transform.Rotate(0, 180, 0);
        faceRight = !faceRight;
    }

    private void Jump()
    {
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Force);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        groundCheck = GetComponentInChildren<GroundCheck>();
    }

    void FixedUpdate()
    {
        #region MoveHorizontal
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (faceRight)
            {
                Reflect();
            }
            MoveHorizontal();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (!faceRight)
            {
                Reflect();
            }
            MoveHorizontal();
        }

        //anim.SetBool("IsWalk", stateHorizontal != 0 && groundCheck.OnGround ? true : false);
        #endregion MoveHorizontal
    }

    void Update()
    {
        #region Jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && groundCheck.OnGround)
        {
            groundCheck.OnGround = false;

            // anim.SetBool("IsJump", true);
            Jump();
        }
        // else if (!Input.GetKeyDown(KeyCode.W) && !groundCheck.OnGround)
        // {
        //     anim.SetBool("IsJump", true);
        // }
        // else if (groundCheck.OnGround)
        // {
        //     anim.SetBool("IsJump", false);
        // }
        #endregion Jump
    }
}