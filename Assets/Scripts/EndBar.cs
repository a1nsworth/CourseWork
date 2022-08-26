using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EndBar : MonoBehaviour
{
    public enum VictoryState
    {
        Nobody,
        Player1,
        Player2
    }

    [SerializeField] private GameObject endGameUI;
    [SerializeField] private Text player1Win;
    [SerializeField] private Text player2Win;

    public static VictoryState victoryState = VictoryState.Nobody;

    private void Start()
    {
        EndGameController.EndGame += OnEndGame;
    }

    private void OnEndGame()
    {
        endGameUI.SetActive(true);

        if (victoryState == VictoryState.Player1)
            player1Win.gameObject.SetActive(true);
        else if (victoryState == VictoryState.Player2)
            player2Win.gameObject.SetActive(true);

        EndGameController.EndGame -= OnEndGame;
    }
}