using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 5.0f;
    public float PlayerJump = 500.0f;
    public float playerHeight = 2.0f;
    Rigidbody2D rb;
    BoxCollider2D playerCollider;

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - playerHeight - 0.1f),
            Vector2.down,
            .01f);
        return hit.transform != null;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
    }
    
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (0 != input.x)
        {
            rb.velocity = new Vector2(input.x * playerSpeed, rb.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(new Vector2(0, PlayerJump));
        }
    }
}
