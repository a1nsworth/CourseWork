using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField] private KeyCode ForwardKey { get; set; }
    [field: SerializeField] private KeyCode BackwardKey { get; set; }
    [field: SerializeField] private KeyCode JumpKey { get; set; }
    [field: SerializeField] private KeyCode AttackKey { get; set; }
    [field: SerializeField] private KeyCode SupperAttackKey { get; set; }

    [SerializeField] public float speedX;
    [SerializeField] private float jumpForce;
    [SerializeField] private float _attackDelay = 3f;

    private bool faceRight = true;
    private float nextAttackTime;

    [SerializeField] private GroundCheck groundCheck;
    
    private Rigidbody2D rb;
    private Animator anim;
    private Player player;

    public event Action BasicShot;
    public event Action SupperShot;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        #region MoveHorizontal

        if (rb.name == "character2")
        {
            if (Input.GetKey(BackwardKey))
            {
                if (faceRight)
                    Reflect();
                MoveHorizontal();

                anim.SetBool("IsWalk", groundCheck.OnGround);
            }

            if (Input.GetKey(ForwardKey))
            {
                if (!faceRight)
                    Reflect();
                MoveHorizontal();

                anim.SetBool("IsWalk", groundCheck.OnGround);
            }

            if (!Input.GetKey(BackwardKey) && !Input.GetKey(ForwardKey))
            {
                anim.SetBool("IsWalk", false);
            }
        }
        else if (rb.name == "character1")
        {
            if (Input.GetKey(BackwardKey))
            {
                if (faceRight)
                    Reflect();
                MoveHorizontal();

                anim.SetBool("IsWalk", groundCheck.OnGround);
            }

            if (Input.GetKey(ForwardKey))
            {
                if (!faceRight)
                    Reflect();
                MoveHorizontal();

                anim.SetBool("IsWalk", groundCheck.OnGround);
            }

            if (!Input.GetKey(BackwardKey) && !Input.GetKey(ForwardKey))
            {
                anim.SetBool("IsWalk", false);
            }
        }

        #endregion MoveHorizontal
    }

    private void Update()
    {
        if (rb.name == "character2")
        {
            if (Input.GetKeyDown(JumpKey) && groundCheck.OnGround)
            {
                anim.SetBool("IsJump", true);

                groundCheck.OnGround = false;
                Jump();
            }
            else if (groundCheck.OnGround)
            {
                anim.SetBool("IsJump", false);
            }

            if (Input.GetKeyDown(AttackKey) && Time.time > nextAttackTime && player.IsPossibleToBasicShot())
            {
                anim.SetTrigger("Attack");
                BasicShot?.Invoke();

                nextAttackTime = Time.time + _attackDelay;
            }

            if (Input.GetKeyDown(SupperAttackKey) && player.IsPossibleToSupperShot())
            {
                anim.SetTrigger("SupperAttack");
                SupperShot?.Invoke();
            }
        }
        else if (rb.name == "character1")
        {
            if (Input.GetKeyDown(JumpKey) && groundCheck.OnGround)
            {
                anim.SetBool("IsJump", true);

                groundCheck.OnGround = false;
                Jump();
            }
            else if (groundCheck.OnGround)
            {
                anim.SetBool("IsJump", false);
            }

            if (Input.GetKeyDown(AttackKey) && Time.time > nextAttackTime && player.IsPossibleToBasicShot())
            {
                anim.SetTrigger("Attack");
                BasicShot?.Invoke();

                nextAttackTime = Time.time + _attackDelay;
            }

            if (Input.GetKeyDown(SupperAttackKey) && player.IsPossibleToSupperShot())
            {
                anim.SetTrigger("SupperAttack");
                SupperShot?.Invoke();
            }
        }
    }

    private void MoveHorizontal() => transform.Translate(speedX, 0, 0);
    private void Jump() => rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

    public void OnSpeedBonus() => speedX += 0.01f;

    private void Reflect()
    {
        transform.Rotate(0, 180, 0);
        faceRight = !faceRight;
    }
}