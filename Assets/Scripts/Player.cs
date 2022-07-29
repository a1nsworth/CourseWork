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

    private void Start()
    {
        Health = basicHealth;
        Lifes = basicLifes;

        rb = GetComponent<Rigidbody2D>();
    }

    public void GetDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            if (Lifes > 1)
                Lifes--;
            else
                Die();
        }

        Debug.Log(Health);
    }

    public void Die()
    {
        Destroy(rb.gameObject);
    }
}
