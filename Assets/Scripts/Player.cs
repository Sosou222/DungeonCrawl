using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamagable
{
    [SerializeField] private LayerMask layerMask;

    public delegate void PlayerMoved();
    public event PlayerMoved OnPlayerMoved;
    public delegate void PlayerTakenDamage(int amount);
    public event PlayerTakenDamage OnPlayerTakenDamage;

    private Vector3 moveTarget;
    private float moveSpeed = 5.0f;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
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

    public void TakeDamage(int amount)
    {
        animator.Play("TakeDamage");
        OnPlayerTakenDamage?.Invoke(amount);
    }

    public Vector2 GetCurrentPosition()
    {
        return new Vector2(moveTarget.x, moveTarget.y);
    }
}
