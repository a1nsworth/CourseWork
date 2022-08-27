using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [field: SerializeField] public int BulletCost { get; private set; } = 10;
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private int rangeX = 10;
    [SerializeField] private int rangeY = 10;

    [SerializeField] private GameObject hitEffect;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    private void FixedUpdate()
    {
        if (IsInRange(rangeX, rangeY))
            Destroy(gameObject);
    }

    private bool IsInRange(int x, int y)
    {
        var position = transform.position;
        return Math.Abs(position.x) > x && Math.Abs(position.y) > y;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();
        if (player)
        {
            player.GetDamage(damage);
        }

        var transform1 = transform;
        Instantiate(hitEffect, transform1.position, transform1.rotation);

        Destroy(gameObject);
    }
}