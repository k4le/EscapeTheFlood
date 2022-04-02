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
    public Animator animator;

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x - transform.localScale.x / 2, transform.position.y - playerHeight / 2 - 0.1f),
            Vector2.right,
            1);
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
            transform.Translate(input.x * playerSpeed * Time.deltaTime, 0, 0);
        }

        Debug.DrawRay(new Vector2(transform.position.x - transform.localScale.x/2, transform.position.y - playerHeight/2 - 0.2f), Vector2.right * 1f, Color.red);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(new Vector2(0, PlayerJump * rb.mass));
            animator.setBool("isInAir", true);
        }
    }
}
