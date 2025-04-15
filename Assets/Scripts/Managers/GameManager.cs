using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void UpdateMovesLeft(int movesLeft);
    public event UpdateMovesLeft OnUpdateMovesLeft;


    [SerializeField] private int movesLeft = 0;

    private void Awake()
    {
        Player player = FindObjectOfType<Player>();
        player.OnPlayerMoved += OnPlayerMoved;
        player.OnPlayerTakenDamage += OnPlayerTakeDamage;
    }

    private void OnPlayerMoved()
    {
        int moveCost = 1;
        LoseMove(moveCost);
    }
    private void OnPlayerTakeDamage(int amount)
    {
        LoseMove(amount);
    }

    private void LoseMove(int amount)
    {
        movesLeft-=amount;
        OnUpdateMovesLeft?.Invoke(movesLeft);
    }

    public int GetMovesLeft()
    {
        return movesLeft;
    }

    public void AddMoves(int amount)
    {
        movesLeft+=amount;
        OnUpdateMovesLeft?.Invoke(movesLeft);
    }
}
