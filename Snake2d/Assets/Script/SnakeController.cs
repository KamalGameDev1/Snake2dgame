using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    private Rigidbody2D body;
    private Vector2 direction = Vector2.right; // start moving right
    public float moveSpeed = 5f;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Prevent backward movement
        if (Input.GetKeyDown(KeyCode.W) && direction != Vector2.down)
            direction = Vector2.up;
        else if (Input.GetKeyDown(KeyCode.S) && direction != Vector2.up)
            direction = Vector2.down;
        else if (Input.GetKeyDown(KeyCode.A) && direction != Vector2.right)
            direction = Vector2.left;
        else if (Input.GetKeyDown(KeyCode.D) && direction != Vector2.left)
            direction = Vector2.right;
    }

    private void FixedUpdate()
    {
        body.velocity = direction * moveSpeed;

        // Rotate snake head based on direction
        if (direction == Vector2.up)
            transform.eulerAngles = Vector3.forward * 0;
        else if (direction == Vector2.down)
            transform.eulerAngles = Vector3.forward * 180;
        else if (direction == Vector2.left)
            transform.eulerAngles = Vector3.forward * 90;
        else if (direction == Vector2.right)
            transform.eulerAngles = Vector3.forward * -90;
    }
}
