// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class KeyboardController : MonoBehaviour
// {

//     [SerializeField] private PlayerController player;

//     [SerializeField] private bool isFirstPlayer;
//     private void Update()
//     {
//         if (player.isFirstPlayer)
//         {
//             if (Input.GetKey(KeyCode.A))
//             {
//                 player.MoveLeft();
//             }
//             if (Input.GetKey(KeyCode.D))
//             {
//                 player.MoveRight();
//             }
//             if (Input.GetKey(KeyCode.W))
//             {
//                 player.Jump();
//             }
//             if (Input.GetKey(KeyCode.S))
//             {
//                 player.Descent();
//             }
//             if (Input.GetKey(KeyCode.T))
//             {
//                 player.SimpleAttack();
//             }
//             if (Input.GetKey(KeyCode.Y))
//             {
//                 player.SupperAttack();
//             }
//         }
//         else
//         {
//             if (Input.GetKey(KeyCode.LeftArrow))
//             {
//                 player.MoveLeft();
//             }
//             if (Input.GetKey(KeyCode.RightArrow))
//             {
//                 player.MoveRight();
//             }
//             if (Input.GetKey(KeyCode.UpArrow))
//             {
//                 player.Jump();
//             }
//             if (Input.GetKey(KeyCode.DownArrow))
//             {
//                 player.Descent();
//             }
//             if (Input.GetKey(KeyCode.N))
//             {
//                 player.SimpleAttack();
//             }
//             if (Input.GetKey(KeyCode.M))
//             {
//                 player.SupperAttack();
//             }
//         }
//     }
// }
