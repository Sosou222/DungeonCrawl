using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;

    public delegate void PlayerMoved();
    public event PlayerMoved OnPlayerMoved;

    private Vector3 moveTarget;
    private float moveSpeed = 5.0f;
    void Start()
    {
        moveTarget = transform.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveTarget, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, moveTarget) < 0.05f)
        {
            float x = InputManager.GetHorizontal();
            float y = InputManager.GetVertical();

            if (Mathf.Abs(x) == Mathf.Abs(y)) y = 0.0f;

            Collider2D colliders = Physics2D.OverlapCircle(new Vector2(x + moveTarget.x, y + moveTarget.y), 0.25f, layerMask);
            if (colliders != null)
            {
                var movable = colliders.GetComponent<IMovable>();
                if (movable != null)
                {
                    movable.Push(new Vector2(x, y));
                    OnPlayerMoved?.Invoke();
                }

                Debug.Log("Wall detected");
                return;
            }

            moveTarget += new Vector3(x, y, 0);
            if (x != 0.0f || y != 0.0f)
            {
                OnPlayerMoved?.Invoke();
            }

        }
    }
}
