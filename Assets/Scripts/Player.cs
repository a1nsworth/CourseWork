using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int basicHealth;
    [SerializeField] private int basicLifes;
    public int Health { get; set; }
    public int Lifes { get; set; }

    private Rigidbody2D rb;
    private Animator animator;


    public void GetDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            if (Lifes <= 1)
            {
                animator.SetTrigger("Die");
            }
            else
            {
                Health = basicHealth;
                Lifes--;
            }
        }
        else
        {
            animator.SetTrigger("Hurt");
        }


        Debug.Log(Health);
    }

    private void Start()
    {
        Health = basicHealth;
        Lifes = basicLifes;

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Math.Abs(transform.position.x) > 10 || Math.Abs(transform.position.y) > 10)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
