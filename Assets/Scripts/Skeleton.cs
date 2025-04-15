using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour, IDamagable, IMovable
{
    [SerializeField] private LayerMask layerMask;
    private float moveSpeed = 12.0f;
    private Vector3 targetPosition;

    void Awake()
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


    public Vector2 GetCurrentPosition()
    {
        return new Vector2(targetPosition.x, targetPosition.y);
    }

    public void Push(Vector2 direction)
    {
        Collider2D colliders = Physics2D.OverlapCircle(new Vector2(direction.x + transform.position.x, direction.y + transform.position.y), 0.25f, layerMask);
        if (colliders != null)
        {
            KillSkeleton();
            return;
        }
        targetPosition += new Vector3(direction.x, direction.y, 0.0f);
    }

    public void TakeDamage(int amount)
    {
        KillSkeleton();
    }

    private void KillSkeleton()
    {
        Destroy(gameObject);
    }
}
