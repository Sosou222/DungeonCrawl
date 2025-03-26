using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;

    private Vector3 moveTarget;
    private float moveSpeed = 5.0f;
    void Start()
    {
        moveTarget = transform.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,moveTarget,moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, moveTarget) < 0.05f)
        {
            float x = InputManager.GetHorizontal();
            float y = InputManager.GetVertical();

            if (Mathf.Abs(x) == Mathf.Abs(y)) y = 0.0f;

            Collider2D colliders = Physics2D.OverlapCircle(new Vector2(x + moveTarget.x, y + moveTarget.y), 0.25f, layerMask);
            if (colliders != null)
            {
                Debug.Log("Wall detected");
                return;
            }

            moveTarget += new Vector3(x, y, 0);
        }

    }
}
