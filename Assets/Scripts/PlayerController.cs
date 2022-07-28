using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    public List<KeyCode> validInputs;
    public float speedX;
    public float jumpForce;
    private bool faceRight = true;

    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private GroundCheck groundCheck;

    [SerializeField] private NewBehaviourScript inputController;

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

    // TODO InputController
    void FixedUpdate()
    {
        #region MoveHorizontal
        if ((inputController.inputs.ContainsKey(KeyCode.LeftArrow) || inputController.inputs.ContainsKey(KeyCode.A)) &&
            (validInputs.Contains(KeyCode.LeftArrow) || validInputs.Contains(KeyCode.LeftArrow)))
        {
            if (faceRight)
            {
                Reflect();
            }
            MoveHorizontal();
        }
        if ((inputController.inputs.ContainsKey(KeyCode.RightArrow) || inputController.inputs.ContainsKey(KeyCode.D)) &&
            (validInputs.Contains(KeyCode.RightArrow) || validInputs.Contains(KeyCode.D)))
        {
            if (faceRight)
            {
                Reflect();
            }
            MoveHorizontal();
        }
        if ((inputController.inputs.ContainsKey(KeyCode.UpArrow) || inputController.inputs.ContainsKey(KeyCode.W)) &&
            (validInputs.Contains(KeyCode.UpArrow) || validInputs.Contains(KeyCode.W)))
        {
            Jump();
        }

        Debug.Log(groundCheck.OnGround);

        //anim.SetBool("IsWalk", stateHorizontal != 0 && groundCheck.OnGround ? true : false);
        #endregion MoveHorizontal
    }

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.W) && groundCheck.OnGround)
        // {
        //     Debug.Log("InJ");
        //     Jump();
        //     groundCheck.OnGround = false;

        //     // anim.SetBool("IsJump", true);
        // }
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