using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public List<KeyCode> validInputs;
    public float speedX;
    public float jumpForce;
    private bool faceRight = true;

    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private GroundCheck groundCheck;
    [SerializeField] private WeaponController weaponController;

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
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        #region MoveHorizontal
        if (rb.name == "character2")
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (faceRight)
                    Reflect();
                MoveHorizontal();

                anim.SetBool("IsWalk", groundCheck.OnGround ? true : false);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (!faceRight)
                    Reflect();
                MoveHorizontal();

                anim.SetBool("IsWalk", groundCheck.OnGround ? true : false);
            }
            if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
            {
                anim.SetBool("IsWalk", false);
            }
        }
        else if (rb.name == "character1")
        {
            if (Input.GetKey(KeyCode.A))
            {
                if (faceRight)
                    Reflect();
                MoveHorizontal();

                anim.SetBool("IsWalk", groundCheck.OnGround ? true : false);
            }
            if (Input.GetKey(KeyCode.D))
            {
                if (!faceRight)
                    Reflect();
                MoveHorizontal();

                anim.SetBool("IsWalk", groundCheck.OnGround ? true : false);
            }

            if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                anim.SetBool("IsWalk", false);
            }
        }
        #endregion MoveHorizontal
    }

    void Update()
    {
        if (rb.name == "character2")
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && groundCheck.OnGround)
            {
                anim.SetBool("IsJump", true);

                groundCheck.OnGround = false;
                Jump();
            }
            else if (!Input.GetKeyDown(KeyCode.UpArrow) && !groundCheck.OnGround)
            {
                anim.SetBool("IsJump", true);
            }
            else if (groundCheck.OnGround)
            {
                anim.SetBool("IsJump", false);
            }

            if (Input.GetKeyDown(KeyCode.N))
            {
                //weaponController.Shoot();
                anim.SetTrigger("Attack");
            }
        }
        else if (rb.name == "character1")
        {
            if (Input.GetKeyDown(KeyCode.W) && groundCheck.OnGround)
            {
                anim.SetBool("IsJump", true);

                groundCheck.OnGround = false;
                Jump();
            }
            else if (!Input.GetKeyDown(KeyCode.W) && !groundCheck.OnGround)
            {
                anim.SetBool("IsJump", true);
            }
            else if (groundCheck.OnGround)
            {
                anim.SetBool("IsJump", false);
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                //weaponController.Shoot();
                anim.SetTrigger("Attack");
            }
        }

        // else if (!Input.GetKeyDown(KeyCode.W) && !groundCheck.OnGround)
        // {
        //     anim.SetBool("IsJump", true);
        // }
        // else if (groundCheck.OnGround)
        // {
        //     anim.SetBool("IsJump", false);
        // }
        // #endregion Jump
    }
}