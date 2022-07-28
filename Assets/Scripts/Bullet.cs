using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
// {
//     [SerializeField] private float speed;
//     [SerializeField] private int damage;

//     private Rigidbody2D rb;
//     void Start()
//     {
//         rb = GetComponent<Rigidbody2D>();
//         rb.velocity = transform.right * speed;
//     }

//     void Update()
//     {
//         if (Math.Abs(transform.position.x) > Math.Abs(10) || Math.Abs(transform.position.y) > Math.Abs(10))
//         {
//             Destroy(gameObject);
//         }
//     }

//     private void OnTriggerEnter2D(Collider2D other)
//     {
//         var player = other.GetComponent<Player>();
//         if (player)
//         {
//             player.GetDamage(damage);
//         }

//         Destroy(gameObject);
//     }
}
