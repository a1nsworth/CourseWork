using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [field: SerializeField] public int BulletCost { get; private set; } = 10;
    [SerializeField] private float speed;
    [SerializeField] private int damage;

    [SerializeField] private GameObject hitEffect;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    private void FixedUpdate()
    {
        if (Math.Abs(transform.position.x) > 10 || Math.Abs(transform.position.y) > 10)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();
        if (player)
        {
            player.GetDamage(damage);
        }

        Instantiate(hitEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}