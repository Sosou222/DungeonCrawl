using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    [SerializeField] private int healAmount = 5;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            FindObjectOfType<GameManager>().AddMoves(healAmount);
            Destroy(gameObject);

        }
    }
}
