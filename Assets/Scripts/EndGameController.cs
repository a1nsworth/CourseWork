using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EndGameController
{
    public static event Action EndGame;
    public static void OnEndGame()
    {
        EndGame?.Invoke();
    }
}
