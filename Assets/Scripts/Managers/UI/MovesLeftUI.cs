using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MovesLeftUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private void Awake()
    {
        GameManager gameManager = FindAnyObjectByType<GameManager>();
        gameManager.OnUpdateMovesLeft += OnUpdateMovesLeft;
        OnUpdateMovesLeft(gameManager.GetMovesLeft());
    }

    private void OnUpdateMovesLeft(int movesLeft)
    {
        text.text = "Moves Left:" + movesLeft;
    }
}
