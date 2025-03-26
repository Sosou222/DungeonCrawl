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
            float x = GetHorizontal();
            float y = GetVertical();

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

    private float GetHorizontal()
    {
        float x = 0.0f;
        if (Input.GetKeyDown(KeyCode.D))
        {
            x = 1.0f;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            x = -1.0f;
        }
        return x;
    }

    private float GetVertical()
    {
        float y = 0;
        if (Input.GetKeyDown(KeyCode.W))
        {
            y = 1.0f;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            y = -1.0f;
        }
        return y;
    }
}
