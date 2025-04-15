using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] private int damageAmount = 1;

    void OnTriggerEnter2D(Collider2D collision)
    {
        IDamagable damagable = collision.GetComponent<IDamagable>();
        if (damagable != null)
        {
            Collider2D col = GetComponent<Collider2D>();
            if (col.OverlapPoint(damagable.GetCurrentPosition()))
            {
                damagable.TakeDamage(damageAmount);
            }

        }
    }
}
