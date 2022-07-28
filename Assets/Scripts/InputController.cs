// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public enum StateMove
// {
//     Left = 0,
//     Right = 1,
//     Up = 2,
//     Down = 3,
//     SimpleAttack = 4,
//     SuperAttack = 5
// }

// public class InputController : MonoBehaviour
// {
//     public Dictionary<KeyCode, StateMove> inputsKeys;
//     Input key;
//     private void Update()
//     {
//         key.Equals
//         if (key == KeyCode.A || key == KeyCode.LeftArrow)
//         {
//             if (!inputsKeys.ContainsKey(key))
//                 inputsKeys.Add(key, StateMove.Left);
//         }
//         else if (key == KeyCode.D || key == KeyCode.RightArrow)
//         {
//             if (!inputsKeys.ContainsKey(key))
//                 inputsKeys.Add(key, StateMove.Right);
//         }
//         else if (key == KeyCode.W || key == KeyCode.UpArrow)
//         {
//             if (!inputsKeys.ContainsKey(key))
//                 inputsKeys.Add(key, StateMove.Up);
//         }
//         else if (key == KeyCode.T || key == KeyCode.N)
//         {
//             if (!inputsKeys.ContainsKey(key))
//                 inputsKeys.Add(key, StateMove.SimpleAttack);
//         }
//         else if (key == KeyCode.Y || key == KeyCode.M)
//         {
//             if (!inputsKeys.ContainsKey(key))
//                 inputsKeys.Add(key, StateMove.SuperAttack);
//         }
//         inputsKeys.Clear();
//     }
// }
