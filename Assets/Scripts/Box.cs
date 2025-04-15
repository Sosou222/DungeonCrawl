using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Box : MonoBehaviour,IMovable
{
    [SerializeField] LayerMask layerMask;
    private float moveSpeed = 12.0f;
    private Vector3 targetPosition;
    public void Push(Vector2 direction)
    {
        Collider2D colliders = Physics2D.OverlapCircle(new Vector2(direction.x + transform.position.x, direction.y + transform.position.y), 0.25f, layerMask);
        if (colliders != null)
        {
            return;
        }
        targetPosition += new Vector3(direction.x, direction.y, 0.0f);
    }

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        if (transform.position == targetPosition)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPosition) < 0.05f)
        {
            transform.position = targetPosition;
        }
    }
}
