using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speedX;
    [SerializeField] private float jumpForce;
    [SerializeField] private List<KeyCode> validInputs;
    [SerializeField] private float _attackDelay = 3f;

    private bool faceRight = true;
    private float nextAttackTime;

    [SerializeField] private GroundCheck groundCheck;
    private Rigidbody2D rb;
    private Animator anim;
    private Player player;

    public event Action Shot;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GetComponent<Player>();
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

                anim.SetBool("IsWalk", groundCheck.OnGround);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (!faceRight)
                    Reflect();
                MoveHorizontal();

                anim.SetBool("IsWalk", groundCheck.OnGround);
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

                anim.SetBool("IsWalk", groundCheck.OnGround);
            }

            if (Input.GetKey(KeyCode.D))
            {
                if (!faceRight)
                    Reflect();
                MoveHorizontal();

                anim.SetBool("IsWalk", groundCheck.OnGround);
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
            else if (groundCheck.OnGround)
            {
                anim.SetBool("IsJump", false);
            }

            if (Input.GetKeyDown(KeyCode.N) && Time.time > nextAttackTime && player.IsPossibleToShot())
            {
                anim.SetTrigger("Attack");
                Shot?.Invoke();

                nextAttackTime = Time.time + _attackDelay;
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
            else if (groundCheck.OnGround)
            {
                anim.SetBool("IsJump", false);
            }

            if (Input.GetKeyDown(KeyCode.T) && Time.time > nextAttackTime && player.IsPossibleToShot())
            {
                anim.SetTrigger("Attack");
                Shot?.Invoke();

                nextAttackTime = Time.time + _attackDelay;
            }
        }
    }

    private void MoveHorizontal() => transform.Translate(speedX, 0, 0);
    private void Jump() => rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

    private void Reflect()
    {
        transform.Rotate(0, 180, 0);
        faceRight = !faceRight;
    }
}