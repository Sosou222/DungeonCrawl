using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void UpdateMovesLeft(int movesLeft);
    public event UpdateMovesLeft OnUpdateMovesLeft;


    private int movesLeft = 0;

    private void Awake()
    {
        Player player = FindObjectOfType<Player>();
        player.OnPlayerMoved += OnPlayerMoved;
    }

    private void OnPlayerMoved()
    {
        LoseMove();
    }

    private void LoseMove()
    {
        movesLeft--;
        OnUpdateMovesLeft?.Invoke(movesLeft);
    }
}
